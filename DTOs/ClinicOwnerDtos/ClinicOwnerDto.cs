namespace DTOs.ClinicOwnerDtos
{
  public class ClinicOwnerDto
  {
    public int OwnerID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int? ClinicID { get; set; }
    public string ClinicName { get; set; }
    public bool Status { get; set; }
  }
}