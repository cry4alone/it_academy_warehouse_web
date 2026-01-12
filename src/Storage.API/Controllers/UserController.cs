using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.UserRequests;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для управления пользователями: получение пользователя по идентификатору и создание нового пользователя.
/// Методы контроллера защищены авторизацией и используют <see cref="IUserService"/> для бизнес-логики.
/// </summary>
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
    
    /// <summary>
    /// Возвращает информацию о пользователе по его идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>200 OK с DTO пользователя.</returns>
    [HttpGet("{userId:int}", Name = "GetUserById")]
    [Authorize(Policy = "User.View")]
    public async Task<IActionResult> GetAsync([FromRoute] int userId, CancellationToken cancellationToken)
    {
        var userResponse = await _userService.GetUserByIdAsync(userId, cancellationToken);
        return Ok(userResponse);
    }
    
    
    /// <summary>
    /// Создаёт нового пользователя.
    /// </summary>
    /// <param name="request">Данные для создания пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>201 Created с DTO созданного пользователя и заголовком Location.</returns>
    [HttpPost]
    [Authorize(Policy = "User.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userResponse = await _userService.CreateUserAsync(request, cancellationToken);

        return CreatedAtRoute("GetUserById", new { userId = userResponse.UserId }, userResponse);
    }
}