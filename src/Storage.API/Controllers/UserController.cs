using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.UserRequests;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("{userId:int}", Name = "GetUserById")]
    [Authorize(Policy = "User.View")]
    public async Task<IActionResult> GetAsync([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var userResponse = await _userService.GetUserByIdAsync(userId, cancellationToken);
        return Ok(userResponse);
    }
    
    
    [HttpPost]
    [Authorize(Policy = "User.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userResponse = await _userService.CreateUserAsync(request, cancellationToken);

        return CreatedAtRoute("GetUserById", new { userId = userResponse.UserId }, userResponse);
    }
}