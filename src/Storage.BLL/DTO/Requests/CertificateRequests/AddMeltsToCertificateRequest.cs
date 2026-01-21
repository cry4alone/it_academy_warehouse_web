namespace Storage.BLL.DTO.Requests.CertificateRequests;

public record AddMeltsToCertificateRequest(
    List<int> MeltIds);