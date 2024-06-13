using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryBusinessObjects
{
  public class ClinicOwner : BaseEntity
  {
    [Key]
    public int OwnerID { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public int ClinicID { get; set; }
    [ForeignKey("ClinicID")]
    public Clinic Clinic { get; set; }
    [ForeignKey("User")]
    public string Id { get; set; }
    public User User { get; set; }

  }
}