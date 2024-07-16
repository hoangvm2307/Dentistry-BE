using DentistryBusinessObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly DBContext _context;

    public AccountRepository(UserManager<User> userManager, SignInManager<User> signInManager, DBContext context)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _context = context;
    }

    public async Task AssignRoleAsync(User user, string role)
    {
      await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<int> GetSpecificUserID(User user)
    {
      var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == user.Id);
      if (customer != null) return customer.CustomerID;

      var dentist = await _context.Dentists.FirstOrDefaultAsync(d => d.Id == user.Id);
      if (dentist != null) return dentist.DentistID;

      var clinicOwner = await _context.ClinicOwners.FirstOrDefaultAsync(co => co.Id == user.Id);
      if (clinicOwner != null) return clinicOwner.OwnerID;

      return 0;
    }
    public async Task<object> GetSpecificUser(User user)
    {
      var customer = await _context.Customers
        .FirstOrDefaultAsync(c => c.Id == user.Id);
      if (customer != null) return customer;

      var dentist = await _context.Dentists
        .FirstOrDefaultAsync(d => d.Id == user.Id);
      if (dentist != null) return dentist;

      var clinicOwner = await _context.ClinicOwners.FirstOrDefaultAsync(co => co.Id == user.Id);
      if (clinicOwner != null) return clinicOwner;

      return 0;
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