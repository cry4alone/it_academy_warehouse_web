using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;

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
    public async Task<IActionResult> GetAsync([FromRoute] int userId)
    {
        var userResponse = await _userService.GetUserByIdAsync(userId);
        return Ok(userResponse);
    }
    
    
    [HttpPost]
    [Authorize(Policy = "User.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateUserRequest request)
    {
        var userResponse = await _userService.CreateUserAsync(request);

        return CreatedAtRoute("GetUserById", new { userId = userResponse.UserId }, userResponse);
    }
}