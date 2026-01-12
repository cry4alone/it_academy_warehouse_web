using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для управления refresh-токенами пользователей.
/// Обеспечивает создание, обновление, удаление и получение токенов из хранилища.
/// </summary>
public interface IRefreshTokenRepository
{
    /// <summary>
    /// Добавляет новый <see cref="RefreshToken"/> в хранилище.
    /// </summary>
    /// <param name="token">Токен для добавления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Добавленный <see cref="RefreshToken"/>.</returns>
    public Task<RefreshToken> AddAsync(RefreshToken token, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет существующий <see cref="RefreshToken"/> в хранилище.
    /// </summary>
    /// <param name="token">Токен с обновлёнными данными.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновлённый <see cref="RefreshToken"/>.</returns>
    public Task<RefreshToken> UpdateAsync(RefreshToken token, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаляет указанный токен из хранилища.
    /// </summary>
    /// <param name="token">Токен для удаления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public Task RemoveAsync(RefreshToken token, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает токен по его строковому значению.
    /// </summary>
    /// <param name="token">Строковое представление токена.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Найденный <see cref="RefreshToken"/>, либо <c>null</c> если не найден.</returns>
    public Task<RefreshToken?> GetAsync(string token, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Удаляет все токены для указанного пользователя.
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public Task RemoveAllAsync(int userId, CancellationToken cancellationToken = default);
}