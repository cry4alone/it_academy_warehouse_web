using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using System.Threading;
using Storage.BLL.DTO.Requests.UserRequests;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для работы с пользователями: получение и создание пользователей.
/// Все операции асинхронны и поддерживают отмену через <see cref="CancellationToken"/>.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Возвращает информацию о пользователе по его идентификатору.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="UserResponse"/>, представляющий данные пользователя.</returns>
    public Task<UserResponse> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создаёт нового пользователя на основе запроса <see cref="CreateUserRequest"/>.
    /// </summary>
    /// <param name="createUserRequest">Данные для создания пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="UserResponse"/> созданного пользователя.</returns>
    public Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken = default);
}