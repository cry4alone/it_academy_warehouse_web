using Storage.DAL.Models;

namespace Storage.BLL.Common.Services.Interfaces;

/// <summary>
/// Сервис, предоставляющий информацию о текущем пользователе, извлекаемую из контекста HTTP.
/// Интерфейс инкапсулирует доступ к идентификатору текущего пользователя и асинхронный метод получения полной модели пользователя.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Идентификатор текущего пользователя, извлекаемый из контекста (claims).
    /// </summary>
    public int UserId { get; }

    /// <summary>
    /// Возвращает модель <see cref="SystemUser"/>, представляющую текущего пользователя.
    /// </summary>
    /// <returns>Экземпляр <see cref="SystemUser"/>, соответствующий текущему пользователю, или <c>null</c>, если пользователь не найден.</returns>
    public Task<SystemUser?> GetCurrentUserAsync();
}