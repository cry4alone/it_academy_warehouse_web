namespace Storage.BLL.DTO.Requests.RoleRequests;

/// <summary>
/// DTO — запрос на создание записи о роли: название роли.
/// </summary>
public record CreateRoleRequest(
    string RoleName);