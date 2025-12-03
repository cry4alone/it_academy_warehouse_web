using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
      private readonly UserService _userService;

      public UserController(UserService userService)
      {
            _userService = userService;
      }

      [HttpGet("{userId:int}")]
      public async Task<IActionResult> GetAsync([FromRoute] UserRequest request)
      {
            var users = await _userService.GetUserByIdAsync(request.UserId);
            return Ok(users);
      }
}