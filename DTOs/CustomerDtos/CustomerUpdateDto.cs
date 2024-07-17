using System.ComponentModel.DataAnnotations;

namespace DTOs.CustomerDtos
{
  public class CustomerUpdateDto
  {
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public bool Status { get; set; }
    public string? Image { get; set; }
  }
}