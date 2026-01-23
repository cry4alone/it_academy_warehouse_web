namespace Storage.BLL.DTO.Requests.CertificateRequests;

/// <summary>
/// DTO — запрос получения информации о сертификате по его идентификатору.
/// </summary>
public record GetCertificateRequest(
    int CertificateId,
    int UserId);