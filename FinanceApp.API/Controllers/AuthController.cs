using FinanceApp.Application.DTOs.Auth;
using FinanceApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace FinanceApp.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var passwordHash = HashPassword(request.Password);

        await _authService.RegisterAsync(request, passwordHash);

        return NoContent();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(new { message = "Login endpoint funcionando" });
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}
