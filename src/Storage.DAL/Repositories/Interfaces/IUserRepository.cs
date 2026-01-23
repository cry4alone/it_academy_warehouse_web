using Storage.DAL.Models;
using System.Threading;
using System.Collections.Generic;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с сущностью пользователя (<see cref="SystemUser"/>).
/// Обеспечивает операции получения пользователя по имени/идентификатору, добавления и получения ролей.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Возвращает пользователя по имени пользователя (username).
    /// </summary>
    /// <param name="username">Имя пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Экземпляр <see cref="SystemUser"/>, если найден; иначе <c>null</c>.</returns>
    public Task<SystemUser?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает пользователя по его идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Экземпляр <see cref="SystemUser"/>, если найден; иначе <c>null</c>.</returns>
    public Task<SystemUser?> GetByIdAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавляет нового пользователя в хранилище.
    /// </summary>
    /// <param name="newUser">Модель нового пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Добавленный экземпляр <see cref="SystemUser"/>.</returns>
    public Task<SystemUser?> AddUserAsync(SystemUser newUser, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает роли пользователя по его идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список ролей пользователя в виде строк.</returns>
    public Task<List<string>> GetUserRolesAsync(int userId, CancellationToken cancellationToken = default);
}