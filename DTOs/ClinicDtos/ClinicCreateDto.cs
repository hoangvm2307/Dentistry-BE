using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.ClinicDtos
{
  public class ClinicCreateDto
  {
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Opening hours are required.")]
    public DateTime OpeningHours { get; set; }
    [Required(ErrorMessage = "Closing hours are required.")]
    [TimeGreaterThan("OpeningHours", ErrorMessage = "Closing hours must be after opening hours.")]
    public DateTime ClosingHours { get; set; }
    public string Image { get; set; }
    public bool Status { get; set; }
  }
}