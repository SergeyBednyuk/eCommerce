using eCommerce.Application.Dtos;
using eCommerce.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest? request)
    {
        if (request is null)
        {
            _logger.LogError("Request is null");
            return BadRequest("Request can't be null");
        }

        _logger.LogInformation("Registering new user");

        var result = await _userService.Register(request);

        if (!result.IsSuccess)
        {
            _logger.LogError($"Register failed for {request.Email} user");
            return BadRequest("Registration failed");
        }

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest? request)
    {
        if (request is null)
        {
            _logger.LogError("Request is null");
            return BadRequest("Request can't be null");
        }

        var result = await _userService.Login(request);

        if (!result.IsSuccess)
        {
            _logger.LogError($"Login failed for {request.Email} user");
            return Unauthorized("Login failed");
        }

        return Ok(result);
    }
}