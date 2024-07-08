namespace DentistryRepositories.Extensions
{
  public class DentistQueryParams: PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public bool Status { get; set; } = true;
    public string? ClinicID { get; set; }
  }
}