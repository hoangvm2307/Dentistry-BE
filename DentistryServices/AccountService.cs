

using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.AccountDto;
using Microsoft.AspNetCore.Identity;

namespace DentistryServices
{
  public class AccountService : IAccountService
  {
    private readonly IAccountRepository _accountRepository;
    private readonly TokenService _tokenService;
    public AccountService(IAccountRepository accountRepository, TokenService tokenService)
    {
      _accountRepository = accountRepository;
      _tokenService = tokenService;
    }
    public async Task<UserDto> LoginAsync(LoginDto loginDto)
    {
      var signInResult = await _accountRepository.LoginAsync(loginDto.Username, loginDto.Password);

      if (signInResult.Succeeded)
      {
        var user = await _accountRepository.GetUserByUsernameAsync(loginDto.Username);

        return new UserDto
        {
          Email = user.Email,
          Token = await _tokenService.GenerateToken(user)
        };
      }

      return null;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      await _accountRepository.AssignRoleAsync(user, "Customer");
      return await _accountRepository.RegisterAsync(user, registerDto.Password);
    }

    public async Task<IdentityResult> RegisterStaffAsync(RegisterDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      await _accountRepository.AssignRoleAsync(user, "ClinicOwner");
      return await _accountRepository.RegisterAsync(user, registerDto.Password);
    }

    public async Task<UserDto> GetCurrentUser(string username)
    {
      var user = await _accountRepository.GetUserByUsernameAsync(username);

      return new UserDto
      {
        Email = user.Email,
        Token = await _tokenService.GenerateToken(user)
      };
    }
  }
}