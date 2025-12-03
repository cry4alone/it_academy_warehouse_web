using Storage.DAL.Models;
using Storage.DAL.Repositories;

namespace Storage.BLL.Services;

public class MeltService
{
    private readonly MeltRepository  _meltRepository;

    public MeltService(MeltRepository meltRepository)
    {
        _meltRepository = meltRepository;
    }

    public async Task<ICollection<Melt>> ListMeltsAsync()
    {
        return await _meltRepository.GetAllAsync();
    }
}