using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class ClinicExtensions
  {
    public static IServiceCollection AddClinicDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<IClinicService, ClinicService>();
      services.AddScoped<IClinicRepository, ClinicRepository>();

      return services;
    }
  }
}