using DTOs.AccountDtos;
using Microsoft.AspNetCore.Identity;
namespace DentistryServices
{
  public interface IAccountService
  {
    Task<IdentityResult> RegisterCustomerAsync(RegisterCustomerDto registerDto);
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> GetCurrentUser(string username);
    Task<IdentityResult> RegisterClinicOwnerAsync(RegisterClinicOwnerDto registerDto);
    Task<IdentityResult> RegisterDentistAsync(RegisterDentistDto registerDto);

  }
}