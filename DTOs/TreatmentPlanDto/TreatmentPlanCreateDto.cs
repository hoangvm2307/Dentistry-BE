using System.ComponentModel.DataAnnotations;

namespace DTOs.TreatmentPlanDto
{
  public class TreatmentPlanCreateDto
  {
    public int CustomerID { get; set; }
    public int DentistID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Frequency { get; set; }
    public DateTime NextAppointmentDate { get; set; }
    [MaxLength(50)]
    public string Status { get; set; }
    [MaxLength(50)]
    public string PaymentStatus { get; set; }
  }
}