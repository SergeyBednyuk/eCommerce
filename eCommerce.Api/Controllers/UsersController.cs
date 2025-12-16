using eCommerce.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUserService userService, ILogger<UsersController> logger) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly ILogger<UsersController> _logger = logger;

    [HttpGet]
    [Route("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        if (userId ==  Guid.Empty) return BadRequest("Invalid user id");
        
        _logger.LogInformation("Retrieving user dor Id {id}", userId);

        var result = await _userService.GetUserById(userId);

        if (!result.IsSuccess)
        {
            _logger.LogWarning(result.Message);
            return NotFound(result);
        }
        
        return Ok(result);
    }
}