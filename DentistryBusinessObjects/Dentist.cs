using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DentistryBusinessObjects
{
  public class Dentist : BaseEntity
  {
    [Key]
    public int DentistID { get; set; }
    [ForeignKey("User")]
    public string Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Specialization { get; set; }

    [ForeignKey("Clinic")]
    public int ClinicID { get; set; }
    public Clinic Clinic { get; set; }
    public List<Appointment> Appointments { get; set; }
    public List<TreatmentPlan> TreatmentPlans { get; set; }
    public List<ChatMessage> ChatMessages { get; set; }
    public User User { get; set; }
  }
}