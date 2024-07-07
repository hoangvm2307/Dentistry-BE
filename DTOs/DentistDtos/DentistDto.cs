using DentistryBusinessObjects;
using DTOs.ClinicDtos;

namespace DTOs.DentistDtos
{
  public class DentistDto
  {
    public int DentistId { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Specialization { get; set; }
    public string? Image { get; set; }
    public int ClinicID { get; set; }
    public ClinicDto? Clinic { get; set; }
    public bool Status { get; set; }
  }
}