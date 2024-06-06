using DentistryBusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace prn_dentistry.API.Data
{
  public class DBInitializer
  {
    public static async Task Initialize(DBContext context, UserManager<User> userManager)
    {
      if (!userManager.Users.Any())
      {
        var user = new User
        {
          UserName = "bob",
          Email = "bobtest@gmail.com"
        };
        await userManager.CreateAsync(user, "Pa$$w0rd");
        await userManager.AddToRoleAsync(user, "Member");

        var admin = new User
        {
          UserName = "admin",
          Email = "admin@gmail.com"
        };
        await userManager.CreateAsync(admin, "Pa$$w0rd");
        await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
      }
    }
  }
}