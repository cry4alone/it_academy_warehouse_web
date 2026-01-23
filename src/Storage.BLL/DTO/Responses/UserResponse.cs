namespace Storage.BLL.DTO.Reponses;

/// <summary>
/// DTO — ответ с информацией о пользователе: идентификатор, логин и ФИО.
/// </summary>
public record UserResponse(
    int UserId,
    string UserName,
    string Surname,
    string FirstName,
    string MiddleName);