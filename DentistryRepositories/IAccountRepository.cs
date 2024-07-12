using DentistryBusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace DentistryRepositories
{
  public interface IAccountRepository
  {
    Task<IdentityResult> RegisterAsync(User user, string password);
    Task<Microsoft.AspNetCore.Identity.SignInResult> LoginAsync(string username, string password);
    Task<User> GetUserByUsernameAsync(string username);
    Task AssignRoleAsync(User user, string role);
    Task<int> GetSpecificUserID(User user);
  }
}