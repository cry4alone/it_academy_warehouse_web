using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.BLL.Services;

public class MeltService : IMeltService
{
    private readonly IMeltRepository  _meltRepository;

    public MeltService(IMeltRepository meltRepository)
    {
        _meltRepository = meltRepository;
    }

    public async Task<ICollection<MeltResponse>> ListMeltsAsync()
    {
        var melts = await _meltRepository.GetAllAsync();
        return melts.Select(MapToMeltResponse).ToList();
    }
    
    public async Task<MeltResponse> GetMeltByIdAsync(int id)
    {
        var melt = await _meltRepository.GetByIdAsync(id);
        if (melt == null) throw new Exception("Melt not found");
        
        return MapToMeltResponse(melt);
    }

    public async Task DeleteMeltAsync(int meltId)
    {
        var meltToUpdate = await _meltRepository.GetByIdAsync(meltId);
        
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
        
        await _meltRepository.CreateAsync(newMelt);
        
        return MapToMeltResponse(newMelt);
    }

    private static MeltResponse MapToMeltResponse(Melt melt)
    {
        return new MeltResponse(
            melt.MeltId,
            melt.ProductionDate,
            melt.MeltStatus?.Name ?? "none",
            melt.Specification?.Name ?? string.Empty,
            melt.Brand?.Name ?? string.Empty
        );
    }

}