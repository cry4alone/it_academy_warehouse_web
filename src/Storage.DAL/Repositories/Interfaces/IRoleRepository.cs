using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с сущностями ролей в хранилище данных.
/// Предоставляет операции получения, создания и обновления ролей.
/// </summary>
public interface IRoleRepository
{
    /// <summary>
    /// Получить все роли из хранилища.
    /// </summary>
    /// <returns>Список сущностей <see cref="Role"/>.</returns>
    public Task<List<Role>> GetAllRolesAsync();

    /// <summary>
    /// Создать новую роль в хранилище.
    /// </summary>
    /// <param name="role">Сущность роли для сохранения.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданная сущность <see cref="Role"/> с присвоенным идентификатором.</returns>
    public Task<Role> CreateRoleAsync(Role role, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить существующую роль в хранилище.
    /// </summary>
    /// <param name="role">Сущность роли с обновлёнными данными.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновлённая сущность <see cref="Role"/>.</returns>
    public Task<Role> UpdateRoleAsync(Role role, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получить роль по её идентификатору.
    /// </summary>
    /// <param name="roleId">Идентификатор роли.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    public Task<Role?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken = default);
}