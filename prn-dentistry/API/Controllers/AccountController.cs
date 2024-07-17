using System.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Text;
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

    // [HttpPost("register-admin")]
    // public async Task<IActionResult> RegisterAdmin()
    // {
    //   var result = await _accountService.RegisterAdmin();

    //   if (result.Succeeded) return Ok("User registered successfully");

    //   return BadRequest(result.Errors);
    // }
    [HttpPost("register-customer")]
    public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterCustomerAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }
    /// <summary>
    /// Register a new clinic owner 
    /// Role: Admin, ClinicOwner
    /// </summary>
    [HttpPost("register-clinicowner")]
    [Authorize(Roles = "Admin,ClinicOwner")]
    public async Task<IActionResult> RegisterClinicOwner([FromBody] RegisterClinicOwnerDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterClinicOwnerAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }
    /// <summary>
    /// Register a new dentist 
    /// Role: Admin, Dentist
    /// </summary>
    [HttpPost("register-dentist")]
    [Authorize(Roles = "Admin,Dentist")]
    public async Task<IActionResult> RegisterDentist([FromBody] RegisterDentistDto registerDto)
    {
      if (registerDto == null || !ModelState.IsValid) return BadRequest("Invalid registration request");

      var result = await _accountService.RegisterDentistAsync(registerDto);

      if (result.Succeeded) return Ok("User registered successfully");

      return BadRequest(result.Errors);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPasswordDirect([FromBody] ResetPasswordDto resetPasswordDto)
    {
      if (resetPasswordDto == null || !ModelState.IsValid) return BadRequest("Invalid request");

      var token = await _accountService.GeneratePasswordResetTokenAsync(resetPasswordDto.Username);
      if (token == null) return BadRequest("User not found");

      var result = await _accountService.ResetPasswordAsync(resetPasswordDto.Username, token, resetPasswordDto.NewPassword);

      if (result.Succeeded) return Ok("Password reset successfully");

      return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
    {
      if (loginDto == null || !ModelState.IsValid) return BadRequest("Invalid login request");

      var user = await _accountService.LoginAsync(loginDto);

      if (user == null) return Unauthorized("Invalid user name or password");

      Response.Cookies.Append("token", user.Token, new CookieOptions { Secure = true, SameSite = SameSiteMode.None, Expires = DateTime.Now.AddDays(7) });

      return user;
    }

    private static void AddCookieToResponse(HttpResponseHeaders headers, System.Net.Cookie cookie)
    {

      var cookieBuilder = new StringBuilder(System.Web.HttpUtility.UrlEncode(cookie.Name) + "=" + System.Web.HttpUtility.UrlEncode(cookie.Value));
      if (cookie.HttpOnly)
      {
        cookieBuilder.Append("; HttpOnly");
      }

      if (cookie.Secure)
      {
        cookieBuilder.Append("; Secure");
      }

      headers.Add("Set-Cookie", cookieBuilder.ToString());
    }

    [Authorize]
    [HttpGet("currentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var user = await _accountService.GetCurrentUser(User.Identity.Name);

      Response.Cookies.Append("token", user.Token, new CookieOptions { Domain = "localhost", Secure = false, HttpOnly = false, SameSite = SameSiteMode.None, IsEssential = true, Expires = DateTime.Now.AddDays(7) });

      return user;
    }

  }
}