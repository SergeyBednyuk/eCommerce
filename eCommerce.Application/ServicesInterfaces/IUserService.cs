using eCommerce.Application.Dtos;

namespace eCommerce.Application.ServicesInterfaces;

/// <summary>
/// Interface 
/// </summary>
public interface IUserService
{
    Task<AuthenticationResponse> Login(LoginRequest request);
    Task<AuthenticationResponse> Register(RegisterRequest request);
}