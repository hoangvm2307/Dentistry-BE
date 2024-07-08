using System.IO;
using System.Text;
using System.Text.Json;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryServices;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using prn_dentistry.API.Data;
using prn_dentistry.API.Extensions;
using Search;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost3000",
      builder => builder
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials()
          .WithOrigins("http://localhost:3000", "https://dentistry-frontend-app.vercel.app"));
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  var jwtSecurityScheme = new OpenApiSecurityScheme
  {
    BearerFormat = "JWT",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.ApiKey,
    Scheme = JwtBearerDefaults.AuthenticationScheme,
    Description = "Put Bearer + your token in the box below",
    Reference = new OpenApiReference
    {
      Id = JwtBearerDefaults.AuthenticationScheme,
      Type = ReferenceType.SecurityScheme
    }
  };

  c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

  c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            jwtSecurityScheme, Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContextPool<DBContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("prn-dentistry")));

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
string json = @"
{
  ""type"": ""service_account"",
  ""project_id"": ""prn-project-75959"",
  ""private_key_id"": ""0b38b36a7b9612d9e5bfd12dd88f4d723b36544a"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQDDghiBesEq9QCm\nO6gmAdXdmdeMxFUpvHcxk1gZ93Z+kuJGw7USF6JAAoTiy2vWxK5gH6Loz0qjWemV\nH9v2v/qK+rcreb3W/R+uCq38zdWmTDjneYVBWV8+b5lYWXyJnB1K4O5ZksnsvBXV\n6JP8G5TVqn8j2DYKK4gJxW7Ff4nmrHfygJf3oB+1S0cYBAewV62fMbLuE8m1Qzpo\nprTkaDopYAJkUi+kIHoNDP5HfoRptk4xPboxGYBd2IITE1hQ6C5LNFuuHMAGTBy0\nS5y/hfiIj6ILoIlVOx8swebeVSHO3WwGBXu3DGs2NwDDiUmzQ63P8Z9IoUxMCq/n\ns01a417lAgMBAAECggEAJ1Px+IfYODsxLn9VJ5IacpmaD9XFuN/RzU3xvMV4F2WW\nMXx4XeOVrpEjKJkZgAov9qOeinz6a2owj+ApCBWdwVvGQW9bphXki8bXsYE5X1q5\nXqzmBpuDCoT6AJj9sZPPG6ssHyYlSuMZ9F30+NOWiLWjnjMFyd1wX+DQk9eARr+k\nXiuhze6+dPHntDkmFm79ujHp7xBIbbgBcChBqUBnarzJAZFazfJ8KrWMhBi7n2H9\npHjJHrqQQL4UHnBK7YlYTR6vfNUdLj8NkZENdeF4bQPkZk/XYeUb+Fqjrh1PqCXg\n1KG7GQ8xQlcxk44B8XhU/ahff8noJaMpBnZqRzepiQKBgQDhCP0awev+9K8YgCTm\nQQkHwmbRbU+CWHroPNDxgu01R8x4iNoTR4S2tDrzS1uZZM/G+KIKKvknLnEFoj9w\nB84fei+Y9D9Dl0geD/Chpm6JVCfHY07slPylmsT6UmQEjKR9pWdUKEQaY5Mnuh4b\n3g5bzLmXD0DNS4c8Rjjczq4ejQKBgQDeaQBgFePj3JwIkbWFL7qwk/Ig0BeeXMxg\nXPDZzeItUBBqJ4tO/CfU+apNouh1gV8UCSLPXEI+bh1uYZ/uZ91/1BUGxzGuD4Az\nFF5+viLha5PQiVTvGIBsSeY0H5sTM13ScFEHd78UsohGaDkw19lFrpXsOqaS+50x\nVVbUvDs3uQKBgQCP2TQZ955I0tZengN4YFhKan1ZIDv0AWVHsSCLUXsaVPQilLB6\nJHx0Yg9Q2HoMOwIKmYLTZxbvceNzi3xru8GKI4vrhS4vobPK67uRSZddF7t53ERm\nPPKnVaDWtvYSZmj7nFDJ3hdymvZFLdbzT2X0TpDQPELbOI2Q/P56P2/UPQKBgQCN\n+UMnEvItY4crJTBVe7lVvKtEbPGWwrAoF0wcDQQDXueLjACug+I9Xr5q3sI7OEFk\nPcy9x6v1xD7/VkxMWHsZfV2KvR8meHiioq8Lgv4rHYv3A6N3GRHpjmboAQDyCckr\na00eUj9ky+6X2zIezrrAc4j6ihoJG5slgc9y71Fx6QKBgQDeVRymJ1pKeUPWJkBZ\nt1lFVAPX1PNogyKr9529a3hCgfyGzoE5A8yba57J9uFUx897lIpABDuWA63o/BDb\nmfZZMKFultyrsbzxmHDilb4TIk52UyDQYVfvAvEwXgBApFTvCnLvKBLvppmx2tx+\nOanO5cKCvgR0LT6VwJBrHH3vkA==\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-esd11@prn-project-75959.iam.gserviceaccount.com"",
  ""client_id"": ""116975163824662417047"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-esd11%40prn-project-75959.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}";
// FirestoreDb firestoreDb = FirestoreDb.Create("prn-project-75959", new FirestoreClientBuilder
// {
//   Credential = GoogleCredential.FromJson(json)
// }.Build());
// builder.Services.AddSingleton(firestoreDb);

builder.Services.AddScoped<TokenService>();


var app = builder.Build();

// FirebaseApp.Create(new AppOptions()
// {
//   Credential = GoogleCredential.FromJson(json)
// });

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
});
// }

app.UseHttpsRedirection();
app.UseCors(opt =>
{
  opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});
app.UseAuthentication();
app.UseAuthorization();

// Serve static files from StaticFiles folder
var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
if (!Directory.Exists(staticFilesPath))
{
  Directory.CreateDirectory(staticFilesPath);
}

app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(staticFilesPath),
  RequestPath = ""
});
// app.MapHub<ChatHub>("/chatHub");
app.MapControllers();

// Serve the HTML file
app.MapGet("/", async context =>
{
  context.Response.ContentType = "text/html";
  await context.Response.SendFileAsync(Path.Combine(staticFilesPath, "index.html"));
});

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DBContext>();
var luceneIndexer = scope.ServiceProvider.GetRequiredService<LuceneIndexer>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
try
{
  // await context.Database.MigrateAsync();
  await DBInitializer.Initialize(context, userManager);
  await SearchIndexInitializer.Initialize(context, luceneIndexer);
}
catch (Exception ex)
{
  logger.LogError(ex, "A problem occurred during migration");
}

// app.MigrateDatabase<DBContext>().Run();
app.Run();
