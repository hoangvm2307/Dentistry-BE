namespace DTOs.AppointmentDtos

{
  public class AppointmentDto
  {
    public int AppointmentID { get; set; }
    public int CustomerID { get; set; }
    public int ClinicScheduleID { get; set; }
    public int ClinicID { get; set; }
    public string ClinicName { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string ClinicPhoneNumber { get; set; }
    public string DentistPhoneNumber { get; set; }
    public decimal Price { get; set; }
    public int DentistID { get; set; }
    public string DentistName { get; set; }
    public int ServiceID { get; set; }
    public string ServiceName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Status { get; set; }
  }
}