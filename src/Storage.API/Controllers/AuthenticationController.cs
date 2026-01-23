using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.DTO.Requests.AuthenticationRequests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

/// <summary>
/// Контроллер для операций аутентификации: вход в систему (login), обновление refresh-токена и выход (logout).
/// Использует <see cref="IAuthenticationService"/> для выполнения бизнес-логики, связанной с токенами.
/// Все методы поддерживают отмену через <see cref="CancellationToken"/> и возвращают соответствующие HTTP-статусы.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    /// <summary>
    /// Выполняет вход пользователя по логину и паролю.
    /// </summary>
    /// <param name="loginRequest">Модель запроса аутентификации, содержащая имя пользователя и пароль.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Возвращает 200 OK с <see cref="AuthenticationResponse"/>, если аутентификация успешна;
    /// 400 BadRequest при некорректном запросе;
    /// 401 Unauthorized при неверных учётных данных.
    /// </returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest? loginRequest, CancellationToken cancellationToken)
    {
        if (loginRequest == null) return BadRequest();

        var loginResponse = await _authenticationService.Authenticate(loginRequest, cancellationToken);
        if (loginResponse == null) return Unauthorized();

        return Ok(loginResponse);
    }

    /// <summary>
    /// Обновляет access- и refresh-токены на основании действующего refresh-токена.
    /// </summary>
    /// <param name="refreshTokenRequest">Модель запроса с текущим refresh-токеном.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Возвращает 200 OK с новым набором токенов (<see cref="AuthenticationResponse"/>) при успешной проверке;
    /// 400 BadRequest при некорректном запросе;
    /// 401 Unauthorized если refresh-токен недействителен или истёк.
    /// </returns>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest? refreshTokenRequest, CancellationToken cancellationToken)
    {
        if (refreshTokenRequest is null) return BadRequest();
        var refreshResponse = await _authenticationService.RefreshToken(refreshTokenRequest, cancellationToken);
        if (refreshResponse == null) return Unauthorized();

        return Ok(refreshResponse);
    }

    /// <summary>
    /// Производит выход пользователя (инвалидацию refresh-токена).
    /// </summary>
    /// <param name="logoutRequest">Модель запроса с refresh-токеном, который должен быть удалён/не действителен далее.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Возвращает 204 NoContent при успешной обработке запроса или 400 BadRequest при некорректном теле запроса.</returns>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest? logoutRequest,
        CancellationToken cancellationToken)
    {
        if (logoutRequest is null) return BadRequest();
        await _authenticationService.Logout(logoutRequest, cancellationToken);
        return NoContent();
    }
}