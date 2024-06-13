using Microsoft.AspNetCore.Identity;

namespace DentistryBusinessObjects
{
  public class User : IdentityUser
  {
    public Dentist Dentist;
    public Customer Customer;
    public ClinicOwner ClinicOwner;
  }
}