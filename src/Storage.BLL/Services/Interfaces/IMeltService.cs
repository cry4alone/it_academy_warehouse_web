using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.DAL.Models;
using System.Threading;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.BLL.Services.Interfaces;

public interface IMeltService
{
    public Task<ICollection<MeltResponse>> ListMeltsAsync(CancellationToken cancellationToken = default);
    public Task<MeltResponse> GetMeltByIdAsync(int meltId, CancellationToken cancellationToken = default);
    public Task DeleteMeltAsync(int meltId, CancellationToken cancellationToken = default);
    public Task<MeltResponse> CreateMeltAsync(CreateMeltRequest melt, CancellationToken cancellationToken = default);
}