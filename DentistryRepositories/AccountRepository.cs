using Microsoft.AspNetCore.Identity;

namespace DentistryRepositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public async Task<IdentityUser> GetUserByUsernameAsync(string username)
    {
      return await _userManager.FindByNameAsync(username);
    }

    public async Task<SignInResult> LoginAsync(string username, string password)
    {
      return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }

    public async Task<IdentityResult> RegisterAsync(IdentityUser user, string password)
    {
      return await _userManager.CreateAsync(user, password);
    }
  }
}