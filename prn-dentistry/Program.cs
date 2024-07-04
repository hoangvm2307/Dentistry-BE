using System.IO;
using System.Text;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryServices;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
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
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:TokenKey"]))
      };
    });
builder.Services.AddAuthorization();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddScoped<TokenService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ILuceneSearcherService>(provider =>
{
  var indexPath = Path.Combine(Directory.GetCurrentDirectory(), "LuceneIndex");
  return new LuceneSearcherService(indexPath);
});


builder.Services.AddSingleton(provider =>
{
  var indexPath = Path.Combine(Directory.GetCurrentDirectory(), "LuceneIndex");
  return new LuceneIndexer(indexPath);
});

var app = builder.Build();
FirebaseApp.Create(new AppOptions()
{
  Credential = GoogleCredential.FromJson(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"))
});
Console.WriteLine(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS_JSON"));
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
app.MapHub<ChatHub>("/chatHub");
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
  await context.Database.MigrateAsync();
  await DBInitializer.Initialize(context, userManager);
  await SearchIndexInitializer.Initialize(context, luceneIndexer);
}
catch (Exception ex)
{
  logger.LogError(ex, "A problem occurred during migration");
}

app.MigrateDatabase<DBContext>().Run();
app.Run();
