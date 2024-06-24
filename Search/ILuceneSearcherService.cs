using DTOs.SearchDtos;

namespace Search
{
    public interface ILuceneSearcherService
    {
        Task<SearchResultDto> SearchAsync(string queryText);
    
    }
}
