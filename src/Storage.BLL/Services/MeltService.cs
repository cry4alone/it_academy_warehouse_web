using AutoMapper;
using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.BLL.Services;

public class MeltService : IMeltService
{
    private readonly IMeltRepository  _meltRepository;
    private readonly IMapper _mapper;

    public MeltService(IMeltRepository meltRepository, IMapper mapper)
    {
        _meltRepository = meltRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<MeltResponse>> ListMeltsAsync()
    {
        var melts = await _meltRepository.GetAllAsync();
        var meltResponses = _mapper.Map<List<MeltResponse>>(melts);
        return meltResponses;
    }
    
    public async Task<MeltResponse> GetMeltByIdAsync(int id)
    {
        var melt = await _meltRepository.GetByIdAsync(id);
        if (melt == null) throw new Exception("Melt not found");
        
        return _mapper.Map<MeltResponse>(melt);
    }

    public async Task DeleteMeltAsync(int meltId)
    {
        var meltToUpdate = await _meltRepository.GetByIdAsync(meltId);
        if (meltToUpdate == null) throw new Exception("Melt not found");
        
        await _meltRepository.UpdateAsync(meltToUpdate);
    }

    public async Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt)
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
        
        var created = await _meltRepository.CreateAsync(newMelt);
        
        return _mapper.Map<MeltResponse>(created);
    }
}