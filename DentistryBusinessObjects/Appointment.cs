using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryBusinessObjects
{
  public class Appointment : BaseEntity
  {
    [Key]
    public int AppointmentID { get; set; }

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }

    [ForeignKey("Dentist")]
    public int DentistID { get; set; }
    public Dentist Dentist { get; set; }

    [ForeignKey("Service")]
    public int ServiceID { get; set; }
    public Service Service { get; set; }

    public DateTime AppointmentDate { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string Status { get; set; }
  }
}