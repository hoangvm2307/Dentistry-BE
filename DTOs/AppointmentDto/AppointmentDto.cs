namespace DTOs.AppointmentDto

{
  public class AppointmentDto
  {
    public int AppointmentID { get; set; }
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public int DentistID { get; set; }
    public string DentistName { get; set; }
    public int ServiceID { get; set; }
    public string ServiceName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Status { get; set; }
  }
}