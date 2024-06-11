using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class CustomerExtensions
  {
    public static IServiceCollection AddCustomerDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();

      return services;
    }
  }
}