namespace Storage.BLL.DTO.Requests.AuthenticationRequests;

/// <summary>
/// DTO — запрос аутентификации с логином (username) и паролем.
/// </summary>
public record AuthenticationRequest(
    string Username,
    string Password
);