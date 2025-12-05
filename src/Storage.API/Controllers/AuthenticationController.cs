using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest? loginRequest)
    {
        if (loginRequest == null) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var loginResponse = await _authenticationService.Authenticate(loginRequest);
        if (loginResponse == null) return Unauthorized();

        return Ok(loginResponse);
    }
    
}