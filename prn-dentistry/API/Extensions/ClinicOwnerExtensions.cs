using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class ClinicOwnerExtensions
  {
    public static IServiceCollection AddClinicOwnerDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<IClinicOwnerService, ClinicOwnerService>();
      services.AddScoped<IClinicOwnerRepository, ClinicOwnerRepository>();

      return services;
    }

    
  }
}