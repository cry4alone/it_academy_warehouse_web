using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.DTO.Requests.AuthenticationRequests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest? loginRequest, CancellationToken cancellationToken)
    {
        if (loginRequest == null) return BadRequest();

        var loginResponse = await _authenticationService.Authenticate(loginRequest, cancellationToken);
        if (loginResponse == null) return Unauthorized();

        return Ok(loginResponse);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest? refreshTokenRequest, CancellationToken cancellationToken)
    {
        if (refreshTokenRequest is null) return BadRequest();
        var refreshResponse = await _authenticationService.RefreshToken(refreshTokenRequest, cancellationToken);
        if (refreshResponse == null) return Unauthorized();

        return Ok(refreshResponse);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] RefreshTokenRequest? logoutRequest,
        CancellationToken cancellationToken)
    {
        if (logoutRequest is null) return BadRequest();
        await _authenticationService.Logout(logoutRequest, cancellationToken);
        return NoContent();
    }
}