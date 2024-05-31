using System.ComponentModel.DataAnnotations;

namespace DentistryBusinessObjects
{
  public class Admin
  {
    [Key]
    public int AdminID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  }
}