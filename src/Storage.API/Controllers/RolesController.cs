using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests.RoleRequests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для управления ролями пользователей.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    /// <summary>
    /// Инициализирует новый экземпляр контроллера <see cref="RolesController"/>.
    /// </summary>
    /// <param name="roleService">Сервис для работы с ролями.</param>
    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    /// <summary>
    /// Получает список всех ролей.
    /// </summary>
    /// <returns>Список ролей.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }
    
    /// <summary>
    /// Получает роль по идентификатору.
    /// </summary>
    /// <param name="roleId">Идентификатор роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Роль с указанным идентификатором.</returns>
    [HttpGet("{roleId:int}", Name = "GetById")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int roleId, CancellationToken cancellationToken)
    {
        var role = await _roleService.GetRoleByIdAsync(roleId, cancellationToken);
        return Ok(role);
    }

    /// <summary>
    /// Создаёт новую роль.
    /// </summary>
    /// <param name="request">Данные для создания роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданная роль.</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        var createdRole = await _roleService.CreateRoleAsync(request, cancellationToken);
        return CreatedAtAction("GetById", new { roleId = createdRole.RoleId }, createdRole);
    }

    /// <summary>
    /// Обновляет разрешения для указанной роли.
    /// </summary>
    /// <param name="request">Данные для обновления разрешений роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Результат без содержимого при успешном обновлении.</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateRolePermissionAsync(UpdateRolePermissionsRequest request,
        CancellationToken cancellationToken)
    {
        await _roleService.UpdateRolePermissionsAsync(request, cancellationToken);
        return NoContent();
    }
}