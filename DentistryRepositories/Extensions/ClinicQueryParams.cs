namespace DentistryRepositories.Extensions
{
  public class ClinicQueryParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public bool Status { get; set; } = true;
  }
}