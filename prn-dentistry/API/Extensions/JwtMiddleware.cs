
using System.Text.Json;

namespace prn_dentistry.API.Extensions
{
  public class JwtMiddleware
  {
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      var token = context.Request.Headers["Authorization"];
      Console.WriteLine($"Token: {token}"); // Ghi log token
      var userClaims = context.User.Claims.Select(c => new { c.Type, c.Value });
      Console.WriteLine("User Claims: " + JsonSerializer.Serialize(userClaims));
      await _next(context);
    }
  }
}