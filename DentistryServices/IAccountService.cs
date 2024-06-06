using DTOs.AccountDto;
using Microsoft.AspNetCore.Identity;
namespace DentistryServices
{
  public interface IAccountService
  {
    Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> GetCurrentUser(string username);
    Task<IdentityResult> RegisterStaffAsync(RegisterDto registerDto);
  }
}