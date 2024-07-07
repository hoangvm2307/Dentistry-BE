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
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.

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

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost3000",
      builder => builder
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials()
          .WithOrigins("http://localhost:3000"));

  options.AddPolicy("AllowProductionDomain",
      builder => builder
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials()
          .WithOrigins("https://dentistry.api.markvoit.id.vn"));
});

builder.Services.AddControllers();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
string json = @"
{
  ""type"": ""service_account"",
  ""project_id"": ""prn-project-75959"",
  ...
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
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
  });

  app.UseCors("AllowLocalhost3000");
}
else
{
  app.UseCors("AllowProductionDomain");
}



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