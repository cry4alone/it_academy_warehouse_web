using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using System.Threading;
using Storage.BLL.DTO.Requests.CertificateRequests;

namespace Storage.BLL.Services.Interfaces;

/// <summary>
/// Сервис для работы с сертификатами: создание, подписание, получение и удаление сертификатов.
/// Описывает операции, которые выполняются на уровне бизнес-логики и возвращают DTO ответов.
/// </summary>
public interface ICertificateService
{
    /// <summary>
    /// Удаляет сертификат по идентификатору.
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата для удаления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает все сертификаты.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список DTO <see cref="CertificateResponse"/>.</returns>
    public Task<List<CertificateResponse>> GetAllCertificatesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает сертификат по его идентификатору.
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="CertificateResponse"/> найденного сертификата.</returns>
    public Task<CertificateResponse> GetCertificateByIdAsync(int certificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Подписывает сертификат (устанавливает информацию о подписавшем и времени обновления).
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата для подписи.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="CertificateResponse"/> подписанного сертификата.</returns>
    public Task<CertificateResponse> SignCertificateAsync(int certificateId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создаёт новый сертификат на основе запроса <see cref="CreateCertificateRequest"/>.
    /// </summary>
    /// <param name="createCertificateRequest">Данные для создания сертификата.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>DTO <see cref="CertificateResponse"/> созданного сертификата.</returns>
    public Task<CertificateResponse> CreateCertificateAsync(CreateCertificateRequest createCertificateRequest, CancellationToken cancellationToken = default);

    /// <summary>
    /// Добавляет плавки к сертификату.
    /// </summary>
    /// <param name="certificateId">Идентификатор плавки.</param>
    /// <param name="request">Данные по плавкам.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task<CertificateResponse> AddMeltsToCertificateAsync(int certificateId, AddMeltsToCertificateRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет плавку из сертификата.
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата.</param>
    /// <param name="meltId">Идентификатор плавки.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task DeleteMeltFromCertificateAsync(int certificateId, int meltId, CancellationToken cancellationToken);
}