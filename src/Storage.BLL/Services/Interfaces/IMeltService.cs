using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.DAL.Models;
using System.Threading;
using Storage.BLL.Common;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для работы с выплавками (melts): получение списка, получение по id, создание и удаление.
/// Методы асинхронны и поддерживают отмену через <see cref="CancellationToken"/>.
/// </summary>
public interface IMeltService
{
    /// <summary>
    /// Возвращает коллекцию всех выплавок в системе.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция DTO <see cref="MeltResponse"/>.</returns>
    public Task<ICollection<MeltResponse>> ListMeltsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает выплавку по её идентификатору.
    /// </summary>
    /// <param name="meltId">Идентификатор выплавки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="MeltResponse"/> найденной выплавки.</returns>
    public Task<MeltResponse> GetMeltByIdAsync(int meltId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаляет выплавку по идентификатору.
    /// </summary>
    /// <param name="meltId">Идентификатор выплавки для удаления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public Task DeleteMeltAsync(int meltId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создаёт новую выплавку на основе запроса <see cref="CreateMeltRequest"/>.
    /// </summary>
    /// <param name="melt">Данные для создания выплавки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="MeltResponse"/> созданной выплавки.</returns>
    public Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Изменяет существующую выплавку на основе запроса <see cref="UpdateMeltRequest"/>.
    /// </summary>
    /// <param name="melt">Данные для изменения в выплавке.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="MeltResponse"/> созданной выплавки.</returns>
    public Task<MeltResponse> UpdateMeltAsync(UpdateMeltRequest melt, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает постраничный набор выплавок (melts).
    /// </summary>
    /// <param name="page">Номер страницы (1‑индексация). Если передано значение меньше 1 — рассматривается как 1.</param>
    /// <param name="pageSize">Количество элементов на странице. Должно быть положительным; Максимум 20 элементов на странице.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Объект <see cref="PagedResponse{MeltResponse}"/>, содержащий коллекцию DTO <see cref="MeltResponse"/> для запрошенной страницы
    /// и метаданные пагинации (общее число элементов, номер страницы, размер страницы и т.д.).
    /// </returns>
    Task<PagedResponse<MeltResponse>> GetPagedMeltsAsync(GetMeltsRequest request, CancellationToken cancellationToken);
}