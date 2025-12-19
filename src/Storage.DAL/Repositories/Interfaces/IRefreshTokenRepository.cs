using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

public interface IRefreshTokenRepository
{
    public Task<RefreshToken> AddAsync(RefreshToken token, CancellationToken cancellationToken = default);
    public Task<RefreshToken> UpdateAsync(RefreshToken token, CancellationToken cancellationToken = default);
    public Task RemoveAsync(RefreshToken token, CancellationToken cancellationToken = default);
    public Task<RefreshToken?> GetAsync(string token, CancellationToken cancellationToken = default);
    
    public Task RemoveAllAsync(CancellationToken cancellationToken = default);
}