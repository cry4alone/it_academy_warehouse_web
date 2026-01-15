namespace Storage.BLL.DTO.Responses;

/// <summary>
/// DTO — ответ с информацией роли (Role).
/// </summary>
public record RoleResponse(
    int RoleId,
    string Name);