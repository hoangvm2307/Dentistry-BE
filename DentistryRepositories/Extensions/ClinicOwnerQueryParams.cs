namespace DentistryRepositories.Extensions
{
  public class ClinicOwnerQueryParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
    public string? ClinicId { get; set; }
    public bool Status { get; set; } = true;
  }
}