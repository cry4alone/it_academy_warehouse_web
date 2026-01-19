using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.BLL.Services;

/// <inheritdoc cref="IMeltService" />
public class MeltService : IMeltService
{
    private readonly IMeltRepository  _meltRepository;
    private readonly IMapper _mapper;

    public MeltService(IMeltRepository meltRepository, IMapper mapper)
    {
        _meltRepository = meltRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<MeltResponse>> ListMeltsAsync(CancellationToken cancellationToken = default)
    {
        var melts = await _meltRepository.GetAllAsync(cancellationToken);
        var meltResponses = _mapper.Map<List<MeltResponse>>(melts);
        return meltResponses;
    }
    
    public async Task<MeltResponse> GetMeltByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var melt = await _meltRepository.GetByIdAsync(id, cancellationToken);
        if (melt == null) throw new KeyNotFoundException("Melt not found");
        
        return _mapper.Map<MeltResponse>(melt);
    }

    public async Task DeleteMeltAsync(int meltId, CancellationToken cancellationToken = default)
    {
        var meltToUpdate = await _meltRepository.GetByIdAsync(meltId, cancellationToken);
        if (meltToUpdate == null) throw new KeyNotFoundException("Melt not found");
        
        await _meltRepository.UpdateAsync(meltToUpdate, cancellationToken);
    }

    public async Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt, CancellationToken cancellationToken = default)
    {
        var newMelt = new Melt
        {
            ProductId = melt.ProductId,
            BrandId = melt.BrandId,
            CertificateId = melt.CertificateId,
            SpecificationId = melt.SpecificationId,
            ProductionDate = melt.ProductionDate,
            MeltStatusId = melt.MeltStatusId
        };
        
        var created = await _meltRepository.CreateAsync(newMelt, cancellationToken);
        
        return _mapper.Map<MeltResponse>(created);
    }
}