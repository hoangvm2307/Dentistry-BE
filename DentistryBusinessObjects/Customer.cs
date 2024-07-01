using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryBusinessObjects
{
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerID { get; set; }
        [ForeignKey("User")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<TreatmentPlan> TreatmentPlans { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }
        public User User { get; set; }

    }
}