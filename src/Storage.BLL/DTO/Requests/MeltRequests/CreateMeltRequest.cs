namespace Storage.BLL.DTO.Requests.MeltRequests;

/// <summary>
/// DTO — запрос на создание записи о плавке: дата производства, статус, спецификация и марка.
/// </summary>
public record CreateMeltRequest(
    int MeltId,
    int ProductId,
    int BrandId,
    int? CertificateId,
    int SpecificationId,  
    DateTime ProductionDate,
    int MeltStatusId);