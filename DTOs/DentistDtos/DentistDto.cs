namespace DTOs.DentistDtos
{
  public class DentistDto
  {
    public int DentistId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Specialization { get; set; }
    public int ClinicID { get; set; }
    public string ClinicName { get; set; }
    public bool Status { get; set; }
  }
}