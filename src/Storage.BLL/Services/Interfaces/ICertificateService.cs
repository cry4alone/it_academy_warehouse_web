using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;

namespace Storage.BLL.Services.Interfaces;

public interface ICertificateService
{
    public Task DeleteCertificateAsync(int certificateId);
    public Task<List<CertificateResponse>> GetAllCertificatesAsync();
    public Task<CertificateResponse> GetCertificateByIdAsync(int certificateId);
    public Task<CertificateResponse> SignCertificateAsync(int certificateId);
    public Task<CertificateResponse> CreateCertificateAsync(CreateCertificateRequest createCertificateRequest);
}