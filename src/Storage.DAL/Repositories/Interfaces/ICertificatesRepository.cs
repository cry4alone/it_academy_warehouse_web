using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

public interface ICertificatesRepository
{
    Task<List<Certificate>> GetAllAsync();
    Task<Certificate?> GetByIdAsync(int id);
    Task<Certificate> CreateAsync(Certificate certificate);
    Task<Certificate> UpdateAsync(Certificate certificate);
}