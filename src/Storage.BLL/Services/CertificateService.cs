using AutoMapper;
using Storage.BLL.Common;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

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

    public async Task DeleteCertificateAsync(int certificateId)
    {
        var certificateToDelete = await _certificatesRepository.GetByIdAsync(certificateId);
        if (certificateToDelete == null) throw new Exception("Certificate not found");
        
        var currentUserId = _currentUserService.UserId;
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        certificateToDelete.DeletedByUserId = currentUserId;
        certificateToDelete.DeletedByUser = currentUser;
        certificateToDelete.DeletedDate = _dateTimeProvider.UtcNow;
        await _certificatesRepository.UpdateAsync(certificateToDelete);
    }

    public async Task<List<CertificateResponse>> GetAllCertificatesAsync()
    {
        var certificates =  await _certificatesRepository.GetAllAsync();
        var certificateResponses = new List<CertificateResponse>();
        
        foreach (var certificate in certificates)
        {
            certificateResponses.Add(_mapper.Map<CertificateResponse>(certificate));
        }
        
        return certificateResponses;
    }

    public async Task<CertificateResponse> GetCertificateByIdAsync(int certificateId)
    {
        var certificate = await _certificatesRepository.GetByIdAsync(certificateId);
        if (certificate == null) throw new Exception("Certificate not found");
        
        return _mapper.Map<CertificateResponse>(certificate);
    }
    
    public async Task<CertificateResponse> CreateCertificateAsync(CreateCertificateRequest createCertificateRequest)
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
        
        await _certificatesRepository.CreateAsync(newCertificate);

        var certificateToMap = await _certificatesRepository.GetByIdAsync(newCertificate.CertificateId);
        
        return _mapper.Map<CertificateResponse>(certificateToMap);
    }

    public async Task<CertificateResponse> SignCertificateAsync(int certificateId)
    {
        var certificate = await _certificatesRepository.GetByIdAsync(certificateId);
        if (certificate == null) throw new Exception("Certificate not found");
        
        var currentUserId = _currentUserService.UserId;
        var currentUser = await _currentUserService.GetCurrentUserAsync();
        
        certificate.UserId = currentUserId;
        certificate.UpdatedByUser = currentUser;
        certificate.UpdatedByUserId = currentUserId;
        certificate.UpdatedDate = _dateTimeProvider.UtcNow;
        
        await _certificatesRepository.UpdateAsync(certificate);
        return _mapper.Map<CertificateResponse>(certificate);
    }
}