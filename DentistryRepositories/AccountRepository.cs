using DentistryBusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace DentistryRepositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public async Task AssignRoleAsync(User user, string role)
    {
      await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
      return await _userManager.FindByNameAsync(username);
    }

    public async Task<SignInResult> LoginAsync(string username, string password)
    {
      return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }

    public async Task<IdentityResult> RegisterAsync(User user, string password)
    {
      return await _userManager.CreateAsync(user, password);
    }
  }
}