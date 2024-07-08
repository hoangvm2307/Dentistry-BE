namespace DentistryRepositories.Extensions
{
  public class SearchParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
  }
}