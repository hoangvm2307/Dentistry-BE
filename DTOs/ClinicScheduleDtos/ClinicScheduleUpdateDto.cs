using System.ComponentModel.DataAnnotations;
namespace DTOs.ClinicScheduleDtos
{
  public class ClinicScheduleUpdateDto
  {
    [Required]
    public string DayOfWeek { get; set; }

    [Required]
    public DateTime OpeningTime { get; set; }

    [Required]
    public DateTime ClosingTime { get; set; }

    [Required]
    public int SlotDuration { get; set; }

    [Required]
    public int MaxPatientsPerSlot { get; set; }
  }
}