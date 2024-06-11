

using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.AccountDtos;
using Microsoft.AspNetCore.Identity;

namespace DentistryServices
{
  public class AccountService : IAccountService
  {
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IClinicOwnerRepository _clinicOwnerRepository;
    private readonly IDentistRepository _dentistRepository;
    private readonly TokenService _tokenService;
    public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository,
      IClinicOwnerRepository clinicOwnerRepository, IDentistRepository dentistRepository, TokenService tokenService)
    {
      _dentistRepository = dentistRepository;
      _customerRepository = customerRepository;
      _clinicOwnerRepository = clinicOwnerRepository;
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

    public async Task<IdentityResult> RegisterCustomerAsync(RegisterCustomerDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      await _accountRepository.RegisterAsync(user, registerDto.Password);
      await _accountRepository.AssignRoleAsync(user, "Customer");

      var customer = new Customer
      {
        Name = registerDto.Name,
        Email = registerDto.Email,
        PhoneNumber = registerDto.PhoneNumber,
        DateOfBirth = registerDto.DateOfBirth,
        Address = registerDto.Address,
        Gender = registerDto.Gender,
        Status = true
      };
      await _customerRepository.AddCustomerAsync(customer);
      return IdentityResult.Success;
    }

    public async Task<IdentityResult> RegisterClinicOwnerAsync(RegisterClinicOwnerDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };
      await _accountRepository.RegisterAsync(user, registerDto.Password);
      await _accountRepository.AssignRoleAsync(user, "ClinicOwner");

      var clinicOwner = new ClinicOwner
      {
        Name = registerDto.Name,
        Email = registerDto.Email,
        PhoneNumber = registerDto.PhoneNumber,
        ClinicID = registerDto.ClinicID,
        Status = true
      };
      await _clinicOwnerRepository.AddClinicOwnerAsync(clinicOwner);
      return IdentityResult.Success;
    }

    public async Task<IdentityResult> RegisterDentistAsync(RegisterDentistDto registerDto)
    {
      var user = new User
      {
        UserName = registerDto.Username,
        Email = registerDto.Email
      };

      await _accountRepository.RegisterAsync(user, registerDto.Password);
      await _accountRepository.AssignRoleAsync(user, "Dentist");

      var dentist = new Dentist{
        Name = registerDto.Name,
        PhoneNumber = registerDto.PhoneNumber,
        Specialization = registerDto.Specialization,
        ClinicID = registerDto.ClinicID,
        Status = true,
      };

      await _dentistRepository.AddDentistAsync(dentist);
      return IdentityResult.Success;
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