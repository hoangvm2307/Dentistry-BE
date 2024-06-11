namespace DTOs.ClinicOwnerDtos
{
  public class ClinicOwnerCreateDto
  {
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int ClinicID { get; set; }
    public bool Status { get; set; }
  }
}