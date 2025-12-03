using Storage.DAL.Models;

namespace Storage.BLL.Services.Interfaces;

public interface IMeltService
{
    public Task<ICollection<Melt>> ListMeltsAsync();
}