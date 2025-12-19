using Storage.DAL.Models;
using System.Threading;

namespace Storage.DAL.Repositories.Interfaces;

public interface IMeltRepository
{
    Task<List<Melt>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Melt?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Melt> CreateAsync(Melt melt, CancellationToken cancellationToken = default);
    Task<Melt> UpdateAsync(Melt melt, CancellationToken cancellationToken = default);
}