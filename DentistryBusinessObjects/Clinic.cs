using System.ComponentModel.DataAnnotations;
namespace DentistryBusinessObjects
{
  public class Clinic : BaseEntity
  {
    [Key]
    public int ClinicID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? Image { get; set; }
    public DateTime OpeningHours { get; set; }
    public DateTime ClosingHours { get; set; }
    public bool Status { get; set; }
    public List<ClinicOwner> ClinicOwners { get; set; }
    public List<Dentist> Dentists { get; set; }
    public List<ClinicSchedule> ClinicSchedules { get; set; }
  }
}