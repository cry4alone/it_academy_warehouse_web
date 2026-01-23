namespace Storage.BLL.DTO.Reponses;

/// <summary>
/// DTO — ответ для аутентификации: данные пользователя и токены доступа/обновления.
/// </summary>
public record AuthenticationResponse(
    int UserId,
    string Username,
    string FirstName,
    string Surname,
    string AccessToken,
    string RefreshToken);