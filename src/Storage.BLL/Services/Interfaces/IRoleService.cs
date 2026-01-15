using Storage.BLL.DTO.Requests.RoleRequests;
using Storage.BLL.DTO.Responses;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для управления ролями и их правами в системе.
/// Предоставляет методы для получения списка ролей, создания роли и обновления прав.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Получить список всех ролей.
    /// </summary>
    /// <returns>Список сущностей <see cref="RoleResponse"/>.</returns>
    public Task<List<RoleResponse>> GetAllRolesAsync();
    
    /// <summary>
    /// Создать новую роль по данным из запроса.
    /// </summary>
    /// <param name="createRoleRequest">DTO с данными для создания роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданная сущность <see cref="RoleResponse"/>.</returns>
    public Task<RoleResponse> CreateRoleAsync(CreateRoleRequest createRoleRequest, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Обновить набор прав для существующей роли согласно переданному запросу.
    /// </summary>
    /// <param name="updateRolePermissionsRequest">DTO с идентификатором роли и новым набором прав.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновлённая сущность <see cref="RoleResponse"/>.</returns>
    public Task UpdateRolePermissionsAsync(UpdateRolePermissionsRequest updateRolePermissionsRequest, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить роль по её идентификатору.
    /// </summary>
    /// <param name="roleId">Идентификатором роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Сущность <see cref="RoleResponse"/>.</returns>
    public Task<RoleResponse> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken = default);
}

