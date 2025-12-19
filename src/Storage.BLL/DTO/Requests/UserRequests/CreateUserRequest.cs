namespace Storage.BLL.DTO.Requests.UserRequests;

public record CreateUserRequest(
    int UserId,
    string? Password,
    string? UserName,
    string? Surname,
    string? FirstName,
    string? MiddleName);