using DTOs.AppointmentDtos;
using DTOs.TreatmentPlanDtos;

namespace DTOs.CustomerDtos
{
  public class CustomerDto
  {
    
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public bool Status { get; set; }

    public List<AppointmentDto> Appointments { get; set; }
    public List<TreatmentPlanDto> TreatmentPlans { get; set; }
  }
}