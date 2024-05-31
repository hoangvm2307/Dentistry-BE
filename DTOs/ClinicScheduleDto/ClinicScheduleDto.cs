namespace DTOs.ClinicScheduleDto
{
  public class ClinicScheduleDto
  {
    public int ScheduleID { get; set; }
    public int ClinicID { get; set; }
    public string DayOfWeek { get; set; }
    public DateTime OpeningTime { get; set; }
    public DateTime ClosingTime { get; set; }
    public int SlotDuration { get; set; }
    public int MaxPatientsPerSlot { get; set; }
  }
}