namespace Storage.BLL.DTO.Requests.MeltRequests;

public record CreateMeltRequest(
    int MeltId,
    int ProductId,
    int BrandId,
    int? CertificateId,
    int SpecificationId,  
    DateTime ProductionDate,
    int MeltStatusId);