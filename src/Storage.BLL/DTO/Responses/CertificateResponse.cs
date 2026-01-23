namespace Storage.BLL.DTO.Reponses;

/// <summary>
/// DTO — ответ с информацией о сертификате: идентификатор, схема контроля,
/// дата создания, склад, пользователь, подписавший, и количество плавок в сертификате.
/// </summary>
public record CertificateResponse(
    int CertificateId,
    string ControlScheme,
    DateTime CreationDate,
    string WarehouseName,
    string? SigningUser,
    int MeltsInCertificate);