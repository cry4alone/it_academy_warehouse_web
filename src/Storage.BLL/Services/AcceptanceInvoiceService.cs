using Storage.BLL.DTO.Requests.AcceptanceInvoiceRequests;
using Storage.BLL.DTO.Responses;
using Storage.BLL.Services.Interfaces;

namespace Storage.BLL.Services;

/// <inheritdoc cref="IAcceptanceInvoiceService"/>
public class AcceptanceInvoiceService : IAcceptanceInvoiceService
{
    public Task<List<AcceptanceInvoiceResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AcceptanceInvoiceResponse> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<AcceptanceInvoiceResponse> CreateAsync(CreateAcceptanceInvoiceRequest acceptanceInvoiceRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SignAcceptanceInvoiceAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}