namespace Storage.BLL.DTO.Requests.UserRequests;

/// <summary>
/// DTO — запрос на создание пользователя: логин и ФИО (имя, фамилия, отчество).
/// </summary>
public record CreateUserRequest(
    int UserId,
    string? Password,
    string? UserName,
    string? Surname,
    string? FirstName,
    string? MiddleName);