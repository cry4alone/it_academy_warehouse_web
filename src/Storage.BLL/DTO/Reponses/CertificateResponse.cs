namespace Storage.BLL.DTO.Reponses;

public record CertificateResponse(
    int CertificateId,
    string ControlScheme,
    DateTime CreationDate,
    string WarehouseName,
    string? SigningUser,
    int MeltsInCertificate);