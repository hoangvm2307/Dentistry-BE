using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Search;

namespace prn_dentistry.API.Extensions
{
  public static class SearchExtensions
  {
    public static IServiceCollection AddSearchDependencyGroup(this IServiceCollection services)
    {
        // services.AddScoped<ILuceneSearcherService, LuceneSearcherService>();
        return services;
    }
  }
}