using FinanceApp.Application.DTOs.Auth;
using FinanceApp.Application.Interfaces;
using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterAsync(RegisterRequest request, string passwordHash)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException("Email already in use");

        var user = new User(request.Name, request.Email, passwordHash);
        await _userRepository.AddAsync(user);
    }
}
