namespace Storage.BLL.DTO.Requests.CertificateRequests;

public record CreateCertificateRequest(
    int UserId,
    int PurchaseOrderId,
    int WarehouseId,
    int ControlSchemeId);