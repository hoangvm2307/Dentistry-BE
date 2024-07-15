using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDtos
{
  public class RegisterDentistDto
  {
    [Required(ErrorMessage = "Username is required.")]
    [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid Phone Number.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Specialization is required.")]
    [StringLength(100, ErrorMessage = "Specialization can't be longer than 100 characters.")]
    public string Specialization { get; set; }
    public string Image { get; set; }

    [Required(ErrorMessage = "Clinic ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Clinic ID must be a positive integer.")]
    public int ClinicID { get; set; }

    public bool Status { get; set; }
  }
}
