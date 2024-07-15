using System.ComponentModel.DataAnnotations;

namespace DTOs.AppointmentDtos

{
  public class AppointmentUpdateDto
  {
    // public int AppointmentID { get; set; }
    [Required(ErrorMessage = "Appointment Date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Invalid Date format.")]
    public DateTime? AppointmentDate { get; set; }
    [Required(ErrorMessage = "Appointment Time is required.")]
    public DateTime? AppointmentTime { get; set; }
    public string Status { get; set; }
  }
}