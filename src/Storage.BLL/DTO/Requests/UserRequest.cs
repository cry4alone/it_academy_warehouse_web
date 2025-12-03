namespace Storage.BLL.DTO.Requests;

public record UserRequest(
    int UserId,
    string? Password,
    string? UserName,
    string? Surname,
    string? FirstName,
    string? MiddleName);