using Storage.DAL.Models;
using System.Threading;

namespace Storage.DAL.Repositories.Interfaces;

public interface ICertificatesRepository
{
    Task<List<Certificate>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Certificate?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Certificate> CreateAsync(Certificate certificate, CancellationToken cancellationToken = default);
    Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken = default);
}