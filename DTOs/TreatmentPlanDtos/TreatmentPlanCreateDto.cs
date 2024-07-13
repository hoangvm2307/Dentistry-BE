using System;
using System.ComponentModel.DataAnnotations;
using DTOs.ValidationsAttributes;

namespace DTOs.TreatmentPlanDtos
{
    public class TreatmentPlanCreateDto
    {
        [Required(ErrorMessage = "Customer ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Customer ID must be a positive number.")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Dentist ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Dentist ID must be a positive number.")]
        public int DentistID { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [CustomDateRange(ErrorMessage = "Start Date cannot be in the past.")]
        public DateTime StartDate { get; set; }

  
        public DateTime? EndDate { get; set; }

        [MaxLength(50, ErrorMessage = "Frequency cannot exceed 50 characters.")]
        public string Description { get; set; }

   
        [DateGreaterThan("StartDate", AllowEqualDates = true, ErrorMessage = "Next Appointment Date must be on or after Start Date.")]
        public DateTime? NextAppointmentDate { get; set; }

        [MaxLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string Status { get; set; }

        [MaxLength(50, ErrorMessage = "Payment Status cannot exceed 50 characters.")]
        public string PaymentStatus { get; set; }
    }

    
}
