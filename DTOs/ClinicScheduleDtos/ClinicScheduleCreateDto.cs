using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.ClinicScheduleDtos
{
  [TimeValidation]
  public class ClinicScheduleCreateDto
  {
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Clinic ID must be a positive integer.")]
    public int ClinicID { get; set; }

    [Required]
    [ValidDayOfWeek]
    public string DayOfWeek { get; set; }

    [Required]
    public DateTime OpeningTime { get; set; }

    [Required]
    public DateTime ClosingTime { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Slot duration must be a positive number.")]
    public int SlotDuration { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Clinic ID must be a positive integer.")]
    public int MaxPatientsPerSlot { get; set; }
  }
}