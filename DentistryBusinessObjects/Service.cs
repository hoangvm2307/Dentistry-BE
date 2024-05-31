using System.ComponentModel.DataAnnotations;

namespace DentistryBusinessObjects
{
  public class Service : BaseEntity
  {
    [Key]
    public int ServiceID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
  }
}