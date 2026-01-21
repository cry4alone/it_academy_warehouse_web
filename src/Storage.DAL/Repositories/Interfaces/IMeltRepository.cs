using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с сущностью <see cref="Melt"/>.
/// Определяет операции получения, создания и обновления выплавок в хранилище данных.
/// </summary>
public interface IMeltRepository
{
    /// <summary>
    /// Возвращает все выплавки (melts) из хранилища.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список всех <see cref="Melt"/> в хранилище.</returns>
    Task<List<Melt>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает выплавку по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор выплавки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Экземпляр <see cref="Melt"/>, если найден; иначе <c>null</c>.</returns>
    Task<Melt?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создаёт новую выплавку в хранилище.
    /// </summary>
    /// <param name="melt">Модель выплавки для создания.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданный экземпляр <see cref="Melt"/>.</returns>
    Task<Melt> CreateAsync(Melt melt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет существующую выплавку в хранилище.
    /// </summary>
    /// <param name="melt">Модель выплавки с обновлёнными полями.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Обновлённый экземпляр <see cref="Melt"/>.</returns>
    Task<Melt> UpdateAsync(Melt melt, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Возвращает множество существующих выплавок по их идентификаторам.
    /// </summary>
    /// <param name="ids">Массив идентификаторов плавок.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Существующие выплавки.</returns>
    Task<HashSet<Melt>> GetExistingByIdsAsync(List<int> ids, CancellationToken cancellationToken = default);
}