using AutoMapper;
using eCommerce.Application.Dtos;
using eCommerce.Application.ServicesInterfaces;
using eCommerce.Domain.Entities;
using eCommerce.Domain.RepositoriesInterfaces;

namespace eCommerce.Application.Services;

internal class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }

    public async Task<AuthenticationResponse> Login(LoginRequest request)
    {
        var result = await _usersRepository.GetUserByEmailAndPasswordAsync(request.Email, request.Password);
        if (result == null)
        {
            return new AuthenticationResponse();
        }

        var response = _mapper.Map<AuthenticationResponse>(result) with { IsSuccess = true, Token = "ValidToken" };
        return response;
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest request)
    {
        var newUser = _mapper.Map<ApplicationUser>(request);

        var result = await _usersRepository.AddUserAsync(newUser);

        if (result == null)
        {
            return new AuthenticationResponse();
        }

        var response = _mapper.Map<AuthenticationResponse>(result) with { IsSuccess = true, Token = "ValidToken" };
        return response;
    }

    public async Task<UserResponse<AppUserDto>> GetUserById(Guid id)
    {
        var result = await _usersRepository.GetUserByUserIdAsync(id);
        
        if (result is null) return UserResponse<AppUserDto>.Failure(null, $"User with {id} id not found");
        
        return UserResponse<AppUserDto>.Success(_mapper.Map<AppUserDto>(result));
    }
}