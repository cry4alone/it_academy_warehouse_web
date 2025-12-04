using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Reponses;
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
    
    [HttpGet]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var authReponse = await _authenticationService.Authenticate(loginRequest);
        
        return Ok(authReponse);
    }
    
}