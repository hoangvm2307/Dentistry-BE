
using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class AppointmentExtensions
  {
    public static IServiceCollection AddAppointmentDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<IAppointmentService, AppointmentService>();
      services.AddScoped<IAppointmentRepository, AppointmentRepository>();

      return services;
    }
  }
}