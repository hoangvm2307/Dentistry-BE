using System;
using System.ComponentModel.DataAnnotations;

namespace DTOs.AppointmentDtos
{
  public class AppointmentCreateDto
  {
    public int ClinicID { get; set; }
    public int ClinicScheduleID { get; set; }

    [Required(ErrorMessage = "Customer ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Customer ID must be a positive number.")]
    public int CustomerID { get; set; }

    [Required(ErrorMessage = "Dentist ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Dentist ID must be a positive number.")]
    public int DentistID { get; set; }

    [Required(ErrorMessage = "Service ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Service ID must be a positive number.")]
    public int ServiceID { get; set; }

    [Required(ErrorMessage = "Appointment Date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid Date format.")]
    public DateTime AppointmentDate { get; set; }

    [Required(ErrorMessage = "Appointment Time is required.")]
    public DateTime AppointmentTime { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    [StringLength(50, ErrorMessage = "Status can't be longer than 50 characters.")]
    public string Status { get; set; }
  }
}
