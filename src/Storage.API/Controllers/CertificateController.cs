using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.CertificateRequests;

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
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var certificateResponses = await _certificateService.GetAllCertificatesAsync(cancellationToken);
        return Ok(certificateResponses);
    }
    
    [HttpPost]
    [Authorize(Policy = "Certificate.Create")]
    public async Task<IActionResult> PostAsync([FromBody] CreateCertificateRequest request, CancellationToken cancellationToken)
    {
        var certificateResponse = await _certificateService.CreateCertificateAsync(request, cancellationToken);
        return CreatedAtRoute("GetCertificateById", new { certificateId = certificateResponse.CertificateId }, certificateResponse);
    }

    [HttpGet("{certificateId:int}", Name = "GetCertificateById")]
    [Authorize(Policy = "Certificate.View")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int certificateId, CancellationToken cancellationToken)
    {
        var certificateResponse = await _certificateService.GetCertificateByIdAsync(certificateId, cancellationToken);
        return Ok(certificateResponse);
    }
    
    [HttpPatch("{certificateId:int}")]
    [Authorize(Policy = "Certificate.Delete")]
    public async Task<IActionResult> SignAsync([FromRoute] int certificateId, CancellationToken cancellationToken)
    {
        await _certificateService.SignCertificateAsync(certificateId, cancellationToken);
        return NoContent();
    }
}