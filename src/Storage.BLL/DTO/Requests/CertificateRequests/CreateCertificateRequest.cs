namespace Storage.BLL.DTO.Requests;

public record CreateCertificateRequest(
    int UserId,
    int PurchaseOrderId,
    int WarehouseId,
    int ControlSchemeId);