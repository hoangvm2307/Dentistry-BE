using DTOs.AccountDtos;
using Microsoft.AspNetCore.Identity;
namespace DentistryServices
{
  public interface IAccountService
  {
    Task<IdentityResult> RegisterCustomerAsync(RegisterCustomerDto registerDto);
    Task<IdentityResult> RegisterAdmin();
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> GetCurrentUser(string username);
    Task<IdentityResult> RegisterClinicOwnerAsync(RegisterClinicOwnerDto registerDto);
    Task<IdentityResult> RegisterDentistAsync(RegisterDentistDto registerDto);
    Task<string> GeneratePasswordResetTokenAsync(string email);
    Task<IdentityResult> ResetPasswordAsync(string email, string token, string newPassword);
  }
} 