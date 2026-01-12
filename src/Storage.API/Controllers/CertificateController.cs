using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.CertificateRequests;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для работы с сертификатами: получение списка, создание, получение по id и подписание.
/// Все методы защищены авторизацией и используют <see cref="ICertificateService"/> для бизнес-логики.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    /// <summary>
    /// Возвращает все сертификаты.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>200 OK с коллекцией DTO сертификатов.</returns>
    [HttpGet]
    [Authorize(Policy = "Certificate.View")]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var certificateResponses = await _certificateService.GetAllCertificatesAsync(cancellationToken);
        return Ok(certificateResponses);
    }
    
    /// <summary>
    /// Создаёт новый сертификат.
    /// </summary>
    /// <param name="request">Данные для создания сертификата.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>201 Created с DTO созданного сертификата и заголовком Location.</returns>
    [HttpPost]
    [Authorize(Policy = "Certificate.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateCertificateRequest request, CancellationToken cancellationToken)
    {
        var certificateResponse = await _certificateService.CreateCertificateAsync(request, cancellationToken);
        return CreatedAtRoute("GetCertificateById", new { certificateId = certificateResponse.CertificateId }, certificateResponse);
    }

    /// <summary>
    /// Возвращает сертификат по его идентификатору.
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>200 OK с DTO найденного сертификата.</returns>
    [HttpGet("{certificateId:int}", Name = "GetCertificateById")]
    [Authorize(Policy = "Certificate.View")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int certificateId, CancellationToken cancellationToken)
    {
        var certificateResponse = await _certificateService.GetCertificateByIdAsync(certificateId, cancellationToken);
        return Ok(certificateResponse);
    }
    
    /// <summary>
    /// Подписывает сертификат (помечает его как подписанный текущим пользователем).
    /// </summary>
    /// <param name="certificateId">Идентификатор сертификата для подписи.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>204 NoContent при успешной подписи.</returns>
    [HttpPatch("{certificateId:int}")]
    [Authorize(Policy = "Certificate.Delete")]
    public async Task<IActionResult> SignAsync([FromRoute] int certificateId, CancellationToken cancellationToken)
    {
        await _certificateService.SignCertificateAsync(certificateId, cancellationToken);
        return NoContent();
    }
}