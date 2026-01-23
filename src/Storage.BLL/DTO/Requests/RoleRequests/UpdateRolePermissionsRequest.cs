namespace Storage.BLL.DTO.Requests.RoleRequests;

/// <summary>
/// DTO — запрос на изменения разрешений для выбранной роли.
/// </summary>
public record UpdateRolePermissionsRequest(
    int RoleId,
    List<int> PermissionIds);