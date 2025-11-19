using eCommerce.Application.Dtos;
using eCommerce.Application.ServicesInterfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;
    //validators
    private readonly IValidator<LoginRequest> _loginRequestValidator;
    private readonly IValidator<RegisterRequest> _registerRequestValidator;

    public AuthController(IUserService userService, ILogger<AuthController> logger,
        IValidator<LoginRequest> loginRequestValidator, IValidator<RegisterRequest> registerRequestValidator)
    {
        _userService = userService;
        _logger = logger;
        _loginRequestValidator = loginRequestValidator;
        _registerRequestValidator = registerRequestValidator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest? request)
    {
        if (request is null)
        {
            _logger.LogError("Request is null");
            return BadRequest("Request can't be null");
        }
        
        var validationResult = await _registerRequestValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return BadRequest(validationResult.ToDictionary());
        
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
    public async Task<IActionResult> Login([FromBody] LoginRequest? request)
    {
        if (request is null)
        {
            _logger.LogError("Request is null");
            return BadRequest("Request can't be null");
        }

        var validationResult = await _loginRequestValidator.ValidateAsync(request);
        if (!validationResult.IsValid) return BadRequest(validationResult.ToDictionary());

        var result = await _userService.Login(request);

        if (!result.IsSuccess)
        {
            _logger.LogError($"Login failed for {request.Email} user");
            return Unauthorized("Login failed");
        }

        return Ok(result);
    }
}