using System.ComponentModel.DataAnnotations;

namespace DentistryBusinessObjects
{
  public class Customer : BaseEntity
  {
    [Key]
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public bool Status { get; set; }

    public List<Appointment> Appointments { get; set; }
    public List<TreatmentPlan> TreatmentPlans { get; set; }
    public List<ChatMessage> ChatMessages { get; set; }
  }
}