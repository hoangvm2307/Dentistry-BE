using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDtos
{
  public class RegisterCustomerDto
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
 
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string? Name { get; set; }

 
    [Phone(ErrorMessage = "Invalid Phone Number.")]
    public string? PhoneNumber { get; set; }

   
    public DateTime? DateOfBirth { get; set; }

 
    [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters.")]
    public string? Address { get; set; }

 
    [StringLength(10, ErrorMessage = "Gender can't be longer than 10 characters.")]
    public string? Gender { get; set; }
    public string? Image { get; set; }

    public bool? Status { get; set; }
  }
}
