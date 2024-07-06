using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistryBusinessObjects;
using DentistryRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace prn_dentistry.API.Extensions
{
  public static class IdentityServiceRegistration
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:TokenKey"]))
        };
        });
      services.AddAuthorization(options =>
      {
        options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
        options.AddPolicy("RequireClinicOwnerRole", policy => policy.RequireRole("ClinicOwner"));
        options.AddPolicy("RequireDentistRole", policy => policy.RequireRole("Dentist"));
      });
      return services;
    }
  }
}