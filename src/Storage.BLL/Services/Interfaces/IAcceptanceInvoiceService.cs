using Storage.BLL.DTO.Requests.AcceptanceInvoiceRequests;
using Storage.BLL.DTO.Responses;
using Storage.DAL.Models;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для работы с накладными приемки (AcceptanceInvoice): получение списка, получение по id, создание и подпись.
/// Методы асинхронны и поддерживают отмену через <see cref="CancellationToken"/>.
/// </summary>
public interface IAcceptanceInvoiceService
{
    /// <summary>
    /// Получает все накладные приемки из хранилища.
    /// </summary>
    /// <returns>Список всех накладных.</returns>
    public Task<List<AcceptanceInvoiceResponse>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Получает накладную приемки по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор накладной приемки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Детали по накладной приемки.</returns>
    public Task<AcceptanceInvoiceResponse> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создает новую накладную приемки на основе запроса <see cref="CreateAcceptanceInvoiceRequest"/>.
    /// </summary>
    /// <param name="acceptanceInvoiceRequest">Данные для создания накладной приемки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Созданную накладную приемки</returns>
    public Task<AcceptanceInvoiceResponse> CreateAsync(CreateAcceptanceInvoiceRequest acceptanceInvoiceRequest, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Подписывает накладную приемки по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор накладной приемки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    public Task SignAcceptanceInvoiceAsync(int id, CancellationToken cancellationToken = default);
}