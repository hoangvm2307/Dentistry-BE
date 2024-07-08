using DentistryRepositories.Extensions;
using DTOs.SearchDtos;

namespace DentistryServices
{
  public interface ISearchService
  {
    Task<SearchResultDto> SearchAsync(SearchParams queryParams);
  }
}