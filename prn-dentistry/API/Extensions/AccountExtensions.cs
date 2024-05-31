

using DentistryRepositories;
using DentistryServices;

namespace prn_dentistry.API.Extensions
{
  public static class AccountExtensions
  {
    public static IServiceCollection AddAccountDependencyGroup(this IServiceCollection services)
    {
      services.AddScoped<IAccountService, AccountService>();
      services.AddScoped<IAccountRepository, AccountRepository>();

      return services;
    }
  }
}