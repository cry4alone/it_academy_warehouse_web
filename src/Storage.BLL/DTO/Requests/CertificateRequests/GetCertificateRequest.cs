namespace Storage.BLL.DTO.Requests;

public record GetCertificateRequest(
    int certificateId,
    int userId);