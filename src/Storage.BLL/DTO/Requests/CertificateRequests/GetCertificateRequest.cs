namespace Storage.BLL.DTO.Requests.CertificateRequests;

public record GetCertificateRequest(
    int CertificateId,
    int UserId);