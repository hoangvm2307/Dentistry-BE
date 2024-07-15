using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.ClinicScheduleDtos
{
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
    [TimeGreaterThan("OpeningTime", ErrorMessage = "Closing Time must be after opening hours.")]
    public DateTime ClosingTime { get; set; }

    [Required]
    [Range(1, 1440, ErrorMessage = "Slot duration must be a positive number, less than 1440.")]
    public int SlotDuration { get; set; }

    [Required]
    [Range(1, 100, ErrorMessage = "Patients must be a positive integer, less than 100.")]
    public int MaxPatientsPerSlot { get; set; }
  }
}