using System.ComponentModel.DataAnnotations;

namespace DTOs.ServiceDto
{
  public class ServiceCreateDto
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public decimal Price { get; set; }
  }
}