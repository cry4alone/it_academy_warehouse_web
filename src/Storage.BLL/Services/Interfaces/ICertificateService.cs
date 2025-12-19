using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using System.Threading;
using Storage.BLL.DTO.Requests.CertificateRequests;

namespace Storage.BLL.Services.Interfaces;

public interface ICertificateService
{
    public Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default);
    public Task<List<CertificateResponse>> GetAllCertificatesAsync(CancellationToken cancellationToken = default);
    public Task<CertificateResponse> GetCertificateByIdAsync(int certificateId, CancellationToken cancellationToken = default);
    public Task<CertificateResponse> SignCertificateAsync(int certificateId, CancellationToken cancellationToken = default);
    public Task<CertificateResponse> CreateCertificateAsync(CreateCertificateRequest createCertificateRequest, CancellationToken cancellationToken = default);
}