using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.TreatmentPlanDtos
{
  public class TreatmentPlanUpdateDto
  {

    [CustomDateRange(ErrorMessage = "Start Date cannot be in the past.")]
    public DateTime StartDate { get; set; }

    [DateGreaterThan("StartDate", ErrorMessage = "End Date must be greater than Start Date.")]
    public DateTime EndDate { get; set; }

    [MaxLength(50, ErrorMessage = "Frequency cannot exceed 50 characters.")]
    public string Description { get; set; }

    public DateTime NextAppointmentDate { get; set; }

    [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
    public string Status { get; set; }

    [MaxLength(50, ErrorMessage = "Payment Status cannot exceed 50 characters.")]
    public string PaymentStatus { get; set; }
  }
}