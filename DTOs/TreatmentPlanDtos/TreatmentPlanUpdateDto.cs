using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.TreatmentPlanDtos
{
  public class TreatmentPlanUpdateDto
  {

    [CustomDateRange(ErrorMessage = "Start Date cannot be in the past.")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DateGreaterThan("StartDate", AllowEqualDates = true, ErrorMessage = "End Date must be on or after Start Date.")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [MaxLength(300, ErrorMessage = "Description cannot exceed 50 characters.")]
    public string Description { get; set; }

    [DateGreaterThan("StartDate", AllowEqualDates = true, ErrorMessage = "Next Appointment Date must be on or after Start Date.")]
    public DateTime? NextAppointmentDate { get; set; }

    [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string Status { get; set; }

    [MaxLength(50, ErrorMessage = "Payment Status cannot exceed 50 characters.")]
    public string PaymentStatus { get; set; }
  }
}