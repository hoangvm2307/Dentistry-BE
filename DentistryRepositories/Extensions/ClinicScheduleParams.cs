namespace DentistryRepositories.Extensions
{
  public class ClinicScheduleParams : PaginationParams
  {
    public string? OrderBy { get; set; }
    public DateTime Date { get; set; }
    public string? SearchTerm { get; set; }
    public string? ClinicID { get; set; }
    public string? ViewType { get; set; }
  }
}