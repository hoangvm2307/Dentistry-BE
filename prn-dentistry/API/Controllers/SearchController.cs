using DTOs.SearchDtos;
using Microsoft.AspNetCore.Mvc;
using Search;

namespace prn_dentistry.API.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly ILuceneSearcherService _searchService;
        public SearchController (ILuceneSearcherService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet]
        public async Task<ActionResult<SearchResultDto>> Search(string query)
        {
            var result = await _searchService.SearchAsync(query);
            return Ok(result);
        }
 
    }
}
