namespace DTOs.AppointmentDto

{
  public class AppointmentUpdateDto
  {
    public int AppointmentID { get; set; }
    public DateTime? AppointmentDate { get; set; }
    public DateTime? AppointmentTime { get; set; }
    public string Status { get; set; }
  }
}