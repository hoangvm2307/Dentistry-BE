namespace DentistryRepositories.Extensions

{
  public class QueryableParam : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public string? ClinicID { get; set; }
    public string? DentistID { get; set; }
    public string? CustomerID { get; set; }
    public string? Status { get; set; }
  }
}