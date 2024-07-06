using DTOs.DentistDtos;

namespace DTOs.ClinicDtos
{
  public class ClinicDto
  {
    public int ClinicID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime OpeningHours { get; set; }
    public DateTime ClosingHours { get; set; }
    public bool Status { get; set; }
    public string Image { get; set;}
    public List<DentistDto> Dentists { get; set; }
  }
}