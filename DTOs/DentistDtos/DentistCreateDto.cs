namespace DTOs.DentistDtos
{
  public class DentistCreateDto
  {
    public string Id{get;set;}
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Specialization { get; set; }
    public int ClinicID { get; set; }
    public bool Status { get; set; }
  }
}