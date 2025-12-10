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
        _authenticationService = authenticationService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequest? loginRequest)
    {
        if (loginRequest == null) return BadRequest();

        var loginResponse = await _authenticationService.Authenticate(loginRequest);
        if (loginResponse == null) return Unauthorized();

        return Ok(loginResponse);
    }
    
}