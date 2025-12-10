using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.DAL.Models;

namespace Storage.BLL.Services.Interfaces;

public interface IMeltService
{
    public Task<ICollection<MeltResponse>> ListMeltsAsync();
    public Task<MeltResponse> GetMeltByIdAsync(int meltId);
    public Task DeleteMeltAsync(int meltId);
    public Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt);
}