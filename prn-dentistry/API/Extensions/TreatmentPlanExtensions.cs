using DentistryRepositories;
using DentistryServices;
 
namespace prn_dentistry.API.Extensions
{
  public  static class TreatmentPlanExtensions
  {
    public static IServiceCollection AddTreatmentPlanDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<ITreatmentPlanService, TreatmentPlanService>();
      services.AddScoped<ITreatmentPlanRepository, TreatmentPlanRepository>();

      return services;
    }
  }
}