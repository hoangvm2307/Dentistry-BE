using System.ComponentModel.DataAnnotations;

namespace DTOs.ServiceDto
{
  public class ServiceUpdateDto
  {
    [Required]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
    public string Name { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    [Required]
    [Range(0, 720, ErrorMessage = "Duration must be less than 720 minutes")]
    public int Duration { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]

    public decimal Price { get; set; }
  }
}