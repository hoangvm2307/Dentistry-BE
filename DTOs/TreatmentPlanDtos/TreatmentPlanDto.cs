namespace DTOs.TreatmentPlanDtos
{
  public class TreatmentPlanDto

  {
    public int PlanID { get; set; }
    public int CustomerID { get; set; }
    public int DentistID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }
    public DateTime? NextAppointmentDate { get; set; }
    public string Status { get; set; }
    public string PaymentStatus { get; set; }
  }
}