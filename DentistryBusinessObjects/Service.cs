using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Clinic")]
        public int ClinicID { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}