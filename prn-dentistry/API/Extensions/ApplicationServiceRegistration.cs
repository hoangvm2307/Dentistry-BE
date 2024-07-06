using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search;

namespace prn_dentistry.API.Extensions
{
  public static class ApplicationServiceRegistration
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddScoped<ILuceneSearcherService>(provider =>
        {
          var indexPath = Path.Combine(Directory.GetCurrentDirectory(), "LuceneIndex");
          return new LuceneSearcherService(indexPath);
        });


      services.AddSingleton(provider =>
      {
        var indexPath = Path.Combine(Directory.GetCurrentDirectory(), "LuceneIndex");
        return new LuceneIndexer(indexPath);
      });


      return services;
    }
  }
}