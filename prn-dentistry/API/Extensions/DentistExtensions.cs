using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class DentistExtensions
  {
    public static IServiceCollection AddDentistDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<IDentistService, DentistService>();
      services.AddScoped<IBaseRepository<Dentist>, DentistRepository>();

      return services;
    }
  }
}