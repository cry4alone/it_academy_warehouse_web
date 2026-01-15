namespace Storage.BLL.DTO.Requests.AuthenticationRequests;

/// <summary>
/// DTO — запрос на обновление access-токена по refresh-токену.
/// </summary>
public record RefreshTokenRequest(
    string Token);