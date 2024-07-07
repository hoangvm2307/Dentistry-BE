using DentistryRepositories.Extensions;
using DentistryServices;
using DTOs.SearchDtos;
using Microsoft.AspNetCore.Mvc;
using Search;

namespace prn_dentistry.API.Controllers
{
  public class SearchController : BaseApiController
  {
    private readonly ILuceneSearcherService _luceneSearchService;
    private readonly ISearchService _searchService;

    public SearchController(ILuceneSearcherService luceneSearchService, ISearchService searchService)
    {
      _luceneSearchService = luceneSearchService;

      _searchService = searchService;
    }
    // [HttpGet]
    // public async Task<ActionResult<SearchResultDto>> LuceneSearch(string query)
    // {
    //   var result = await _luceneSearchService.SearchAsync(query);
    //   return Ok(result);
    // }

    [HttpGet]
    public async Task<ActionResult<SearchResultDto>> Search([FromQuery]QueryableParam queryParams)
    {
      var result = await _searchService.SearchAsync(queryParams);
      return Ok(result);
    }

  }
}
