using System.Transactions;
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
    private readonly IBaseRepository<Dentist> _dentistRepository;
    private readonly TokenService _tokenService;
    public AccountService(IAccountRepository accountRepository, ICustomerRepository customerRepository,
      IClinicOwnerRepository clinicOwnerRepository, IBaseRepository<Dentist> dentistRepository, TokenService tokenService)
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
      using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
        try
        {
          var user = new User
          {
            UserName = registerDto.Username,
            Email = registerDto.Email
          };

          var userCreationResult = await _accountRepository.RegisterAsync(user, registerDto.Password);
          if (!userCreationResult.Succeeded)
          {
            return userCreationResult;
          }

          await _accountRepository.AssignRoleAsync(user, "Customer");

          var customer = new Customer
          {
            Id = user.Id,
            Name = registerDto.Name,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            DateOfBirth = registerDto.DateOfBirth,
            Address = registerDto.Address,
            Gender = registerDto.Gender,
            Status = true
          };
          await _customerRepository.AddCustomerAsync(customer);

          transaction.Complete();

          return IdentityResult.Success;
        }
        catch (Exception)
        {
          return IdentityResult.Failed(new IdentityError { Description = "An error occurred while registering the customer." });
        }
      }
    }

    public async Task<IdentityResult> RegisterClinicOwnerAsync(RegisterClinicOwnerDto registerDto)
    {
      using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
        try
        {
          var user = new User
          {
            UserName = registerDto.Username,
            Email = registerDto.Email
          };

          var userCreationResult = await _accountRepository.RegisterAsync(user, registerDto.Password);
          if (!userCreationResult.Succeeded)
          {
            return userCreationResult;
          }

          await _accountRepository.AssignRoleAsync(user, "ClinicOwner");

          var clinicOwner = new ClinicOwner
          {
            Id = user.Id,
            Name = registerDto.Name,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            ClinicID = registerDto.ClinicID,
            Status = registerDto.Status
          };
          await _clinicOwnerRepository.AddClinicOwnerAsync(clinicOwner);

          transaction.Complete();

          return IdentityResult.Success;
        }
        catch (Exception)
        {
          return IdentityResult.Failed(new IdentityError { Description = "An error occurred while registering the clinic owner." });
        }
      }
    }

    public async Task<IdentityResult> RegisterDentistAsync(RegisterDentistDto registerDto)
    {
      using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
        try
        {
          var user = new User
          {
            UserName = registerDto.Username,
            Email = registerDto.Email
          };

          var userCreationResult = await _accountRepository.RegisterAsync(user, registerDto.Password);
          if (!userCreationResult.Succeeded)
          {
            return userCreationResult;
          }

          await _accountRepository.AssignRoleAsync(user, "Dentist");

          var dentist = new Dentist
          {
            Email = registerDto.Email,
            Name = registerDto.Name,
            PhoneNumber = registerDto.PhoneNumber,
            Specialization = registerDto.Specialization,
            ClinicID = registerDto.ClinicID,
            Status = registerDto.Status,
            Id = user.Id
          };

          await _dentistRepository.AddAsync(dentist);

          transaction.Complete();

          return IdentityResult.Success;
        }
        catch (Exception)
        {
          return IdentityResult.Failed(new IdentityError { Description = "An error occurred while registering the dentist." });
        }
      }
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