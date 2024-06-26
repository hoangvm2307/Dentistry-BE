using DentistryServices;
using DTOs.AccountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace prn_dentistry.API.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpPost("register-customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterCustomerAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }

    [HttpPost("register-clinicowner")]
    public async Task<IActionResult> RegisterClinicOwner([FromBody] RegisterClinicOwnerDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterClinicOwnerAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }

    [HttpPost("register-dentist")]
    public async Task<IActionResult> RegisterDentist([FromBody] RegisterDentistDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterDentistAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
    {
      if (loginDto == null || !ModelState.IsValid) return BadRequest("Invalid login request");

      var user = await _accountService.LoginAsync(loginDto);

      if (user == null) return Unauthorized("Invalid user name or password");

      return user;
    }

    [Authorize]
    [HttpGet("currentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      return await _accountService.GetCurrentUser(User.Identity.Name);
    }

  }
}