using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpGet]
    [Authorize(Policy = "Certificate.View")]
    public async Task<IActionResult> GetAsync()
    {
        var certificateResponses = await _certificateService.GetAllCertificatesAsync();
        return Ok(certificateResponses);
    }
    
    [HttpPost]
    [Authorize(Policy = "Certificate.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateCertificateRequest request)
    {
        var certificateResponse = await _certificateService.CreateCertificateAsync(request);
        return CreatedAtRoute("GetCertificateById", new { certificateId = certificateResponse.CertificateId }, certificateResponse);
    }

    [HttpGet("{certificateId:int}", Name = "GetCertificateById")]
    [Authorize(Policy = "Certificate.View")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int certificateId)
    {
        var certificateResponse = await GetByIdAsync(certificateId);
        return Ok(certificateResponse);
    }
    
    [HttpPatch("{certificateId:int}")]
    [Authorize(Policy = "Certificate.Delete")]
    public async Task<IActionResult> SignAsync([FromRoute] int certificateId)
    {
        await _certificateService.SignCertificateAsync(certificateId);
        return NoContent();
    }
}