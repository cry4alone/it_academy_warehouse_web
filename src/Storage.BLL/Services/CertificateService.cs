using AutoMapper;
using Storage.BLL.Common;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using System.Threading;
using Storage.BLL.DTO.Requests.CertificateRequests;

namespace Storage.BLL.Services;

public class CertificateService : ICertificateService
{
    private readonly ICertificatesRepository  _certificatesRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMapper _mapper;

    public CertificateService(ICertificatesRepository certificatesRepository,
        ICurrentUserService currentUserService,
        IDateTimeProvider dateTimeProvider, IMapper mapper)
    {
        _certificatesRepository = certificatesRepository;
        _currentUserService = currentUserService;
        _dateTimeProvider = dateTimeProvider;
        _mapper = mapper;
    }

    public async Task DeleteCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
    {
        var certificateToDelete = await _certificatesRepository.GetByIdAsync(certificateId, cancellationToken);
        if (certificateToDelete == null) throw new Exception("Certificate not found");
        
        var currentUserId = _currentUserService.UserId;
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        certificateToDelete.DeletedByUserId = currentUserId;
        certificateToDelete.DeletedByUser = currentUser;
        certificateToDelete.DeletedDate = _dateTimeProvider.UtcNow;
        await _certificatesRepository.UpdateAsync(certificateToDelete, cancellationToken);
    }

    public async Task<List<CertificateResponse>> GetAllCertificatesAsync(CancellationToken cancellationToken = default)
    {
        var certificates =  await _certificatesRepository.GetAllAsync(cancellationToken);
        var certificateResponses = new List<CertificateResponse>();
        
        foreach (var certificate in certificates)
        {
            certificateResponses.Add(_mapper.Map<CertificateResponse>(certificate));
        }
        
        return certificateResponses;
    }

    public async Task<CertificateResponse> GetCertificateByIdAsync(int certificateId, CancellationToken cancellationToken = default)
    {
        var certificate = await _certificatesRepository.GetByIdAsync(certificateId, cancellationToken);
        if (certificate == null) throw new Exception("Certificate not found");
        
        return _mapper.Map<CertificateResponse>(certificate);
    }
    
    public async Task<CertificateResponse> CreateCertificateAsync(CreateCertificateRequest createCertificateRequest, CancellationToken cancellationToken = default)
    {
        var currentUserId = _currentUserService.UserId;
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        var newCertificate = new Certificate()
        {
            ControlSchemeId = createCertificateRequest.ControlSchemeId,
            WarehouseId = createCertificateRequest.WarehouseId,
            PurchaseOrderId = createCertificateRequest.PurchaseOrderId,
            CreatedByUser = currentUser,
            CreatedByUserId = currentUserId,
            CreatedDate = _dateTimeProvider.UtcNow,
        };
        
        var created = await _certificatesRepository.CreateAsync(newCertificate, cancellationToken);

        var certificateToMap = await _certificatesRepository.GetByIdAsync(created.CertificateId, cancellationToken);
        
        return _mapper.Map<CertificateResponse>(certificateToMap);
    }

    public async Task<CertificateResponse> SignCertificateAsync(int certificateId, CancellationToken cancellationToken = default)
    {
        var certificate = await _certificatesRepository.GetByIdAsync(certificateId, cancellationToken);
        if (certificate == null) throw new Exception("Certificate not found");
        
        var currentUserId = _currentUserService.UserId;
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        certificate.UserId = currentUserId;
        certificate.UpdatedByUser = currentUser;
        certificate.UpdatedByUserId = currentUserId;
        certificate.UpdatedDate = _dateTimeProvider.UtcNow;
        
        await _certificatesRepository.UpdateAsync(certificate, cancellationToken);
        return _mapper.Map<CertificateResponse>(certificate);
    }
}