namespace DTOs.AccountDtos
{
  public class RegisterClinicOwnerDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public int ClinicID { get; set; }
    public bool Status { get; set; }
  }
}