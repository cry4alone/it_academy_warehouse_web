using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с сущностью <see cref="Certificate"/>.
/// Определяет операции получения, создания и обновления сертификатов в хранилище данных.
/// </summary>
public interface ICertificatesRepository
{
    /// <summary>
    /// Возвращает все сертификаты из хранилища с подгрузкой связанных сущностей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список всех <see cref="Certificate"/> в хранилище.</returns>
    Task<List<Certificate>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает сертификат по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сертификата.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Экземпляр <see cref="Certificate"/>, если найден; иначе <c>null</c>.</returns>
    Task<Certificate?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создаёт новый сертификат в хранилище.
    /// </summary>
    /// <param name="certificate">Модель сертификата для создания.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный экземпляр <see cref="Certificate"/> с заполненным идентификатором и связанными данными.</returns>
    Task<Certificate> CreateAsync(Certificate certificate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет существующий сертификат в хранилище.
    /// </summary>
    /// <param name="certificate">Модель сертификата с обновлёнными полями.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновлённый экземпляр <see cref="Certificate"/>.</returns>
    Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken = default);
}