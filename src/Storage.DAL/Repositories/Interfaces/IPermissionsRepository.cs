using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для управления разрешениям(доступами) для ролей.
/// Обеспечивает создание, обновление, удаление и получение ролей из хранилища.
/// </summary>
public interface IPermissionRepository
{
    /// <summary>
    /// Получает все доступы из хранилища.
    /// </summary>
    /// <returns>Список доступов.</returns>
    public Task<List<Permission>> GetAllAsync();

    /// <summary>
    /// Получает доступ по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор доступа.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Доступ.</returns>
    public Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    public Task AddRolePermissionsAsync(List<RolePermission> rolePermission, CancellationToken cancellationToken = default);
    
    public Task<HashSet<int>> GetExistingIdsAsync(List<int> permissionIds, CancellationToken cancellationToken = default);
    
    public Task<HashSet<int>> GetExistingRolePermissionsById(int id, CancellationToken cancellationToken = default);
}