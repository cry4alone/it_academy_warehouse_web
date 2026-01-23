namespace Storage.BLL.DTO.Requests.CertificateRequests;

/// <summary>
/// DTO — запрос на создание сертификата: идентификаторы пользователя, заказа,
/// склада и схемы контроля.
/// </summary>
public record CreateCertificateRequest(
    int UserId,
    int PurchaseOrderId,
    int WarehouseId,
    int ControlSchemeId);