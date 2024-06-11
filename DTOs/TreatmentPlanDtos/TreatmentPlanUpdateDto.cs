using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.TreatmentPlanDtos
{
  public class TreatmentPlanUpdateDto
  {
    [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [CustomDateRange(ErrorMessage = "Start Date cannot be in the past.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", ErrorMessage = "End Date must be greater than Start Date.")]
        public DateTime EndDate { get; set; }

        [MaxLength(50, ErrorMessage = "Frequency cannot exceed 50 characters.")]
        public string Frequency { get; set; }

        [DataType(DataType.Date)]
        [DateGreaterThan("StartDate", AllowEqualDates = true, ErrorMessage = "Next Appointment Date must be on or after Start Date.")]
        public DateTime NextAppointmentDate { get; set; }

        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; }

        [MaxLength(50, ErrorMessage = "Payment Status cannot exceed 50 characters.")]
        public string PaymentStatus { get; set; }
  }
}