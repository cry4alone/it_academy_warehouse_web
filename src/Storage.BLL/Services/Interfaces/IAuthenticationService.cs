using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests.AuthenticationRequests;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис аутентификации: отвечает за вход пользователя, обновление refresh-токена и выход (logout).
/// Описывает операции, связанные с генерацией и валидацией токенов доступа и refresh-токенов.
/// </summary>
public interface IAuthenticationService
{
    /// <summary>
    /// Выполняет аутентификацию пользователя по логину и паролю.
    /// </summary>
    /// <param name="request">Запрос для аутентификации, содержащий имя пользователя и пароль.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>При успешной аутентификации возвращает <see cref="AuthenticationResponse"/> с access и refresh токенами; иначе <c>null</c>.</returns>
    Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет refresh-токен: валидирует старый refresh-токен и выдаёт новый набор токенов.
    /// </summary>
    /// <param name="refreshToken">Запрос, содержащий строковое значение текущего refresh-токена.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Если refresh-токен действителен — возвращает новый <see cref="AuthenticationResponse"/>; иначе <c>null</c> (пользователь должен пройти аутентификацию заново).</returns>
    Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default);

    /// <summary>
    /// Производит выход пользователя (logout) — удаляет/инвалидирует указанный refresh-токен.
    /// </summary>
    /// <param name="refreshToken">Запрос с refresh-токеном, который необходимо удалить.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task Logout(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default);
}