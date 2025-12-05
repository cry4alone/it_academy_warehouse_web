using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // Добавлено Name для явного именованного маршрута
    [HttpGet("{userId:int}", Name = "GetUserById")]
    public async Task<IActionResult> GetAsync([FromRoute] int userId)
    {
        var userResponse = await _userService.GetUserByIdAsync(userId);
        if (userResponse == null) return NotFound();
        return Ok(userResponse);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserRequest request)
    {
        var currentUsername = HttpContext.User.FindFirst("sub")?.Value;

        var userResponse = await _userService.CreateUserAsync(request, currentUsername);
        if (userResponse == null) return BadRequest();

        // Если Id не назначен — не пытаться генерировать маршрут
        if (userResponse.UserId <= 0)
        {
            return Ok(userResponse);
        }

        // Используем именованный маршрут — надёжнее при рефакторинге маршрутов
        return CreatedAtRoute("GetUserById", new { userId = userResponse.UserId }, userResponse);
    }
}