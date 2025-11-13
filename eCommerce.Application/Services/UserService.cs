using eCommerce.Application.Dtos;
using eCommerce.Application.ServicesInterfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.RepositoriesInterfaces;

namespace eCommerce.Application.Services;

internal class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;

    public UserService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<AuthenticationResponse> Login(LoginRequest request)
    {
        var result = await _usersRepository.GetUserByEmailAndPasswordAsync(request.Email, request.Password);
        if (result == null)
        {
            return new AuthenticationResponse();
        }

        return new AuthenticationResponse(result.UserID, result.Email,
            $"{result.FirstName}  {result.LastName}", result.Gender, "ValidToken", true);
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest request)
    {
        var newUser = new ApplicationUser
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Gender = request.Gender.ToString(),
            Pasword = request.Password,
        };
        
        var result = await _usersRepository.AddUserAsync(newUser);

        if (result == null)
        {
            return new AuthenticationResponse();
        }
        
        return new AuthenticationResponse(result.UserID, result.Email,
            $"{result.FirstName}  {result.LastName}", result.Gender, "ValidToken", true);
    }
}