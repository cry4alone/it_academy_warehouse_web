using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

public interface IMeltRepository
{
    Task<List<Melt>> GetAllAsync();
    Task<Melt?> GetByIdAsync(int id);
    Task<Melt> CreateAsync(Melt melt);
    Task<Melt> UpdateAsync(Melt melt);
}