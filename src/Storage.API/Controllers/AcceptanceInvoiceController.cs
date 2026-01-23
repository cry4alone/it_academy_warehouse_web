using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.BLL.DTO.Requests.AcceptanceInvoiceRequests;
using Storage.BLL.Services.Interfaces;

namespace Storage.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AcceptanceInvoiceController : ControllerBase
{
    private readonly IAcceptanceInvoiceService _acceptanceInvoiceService;
    
    public AcceptanceInvoiceController(IAcceptanceInvoiceService acceptanceInvoiceService)
    {
        _acceptanceInvoiceService = acceptanceInvoiceService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var invoices = await _acceptanceInvoiceService.GetAllAsync(cancellationToken);
        return Ok(invoices);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var invoice = await _acceptanceInvoiceService.GetByIdAsync(id, cancellationToken);
        return Ok(invoice);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAcceptanceInvoiceRequest request, CancellationToken cancellationToken)
    {
        var createdInvoice = await _acceptanceInvoiceService.CreateAsync(request, cancellationToken);
        return Ok(createdInvoice);
    }

    [HttpPut("{id}/sign")]
    public async Task<IActionResult> SignAcceptanceInvoiceAsync(int id, CancellationToken cancellationToken)
    {
        await _acceptanceInvoiceService.SignAcceptanceInvoiceAsync(id, cancellationToken);
        return NoContent();
    }
}