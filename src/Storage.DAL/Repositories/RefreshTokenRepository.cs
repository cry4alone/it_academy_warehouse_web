using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

/// <inheritdoc cref="IRefreshTokenRepository" />
public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly WarehouseContext _context;

    /// <summary>
    /// Создаёт экземпляр репозитория для refresh-токенов с указанным контекстом БД.
    /// </summary>
    /// <param name="context">Контекст БД.</param>
    /// <exception cref="ArgumentNullException">Если <paramref name="context"/> равен <c>null</c>.</exception>
    public RefreshTokenRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken> AddAsync(RefreshToken token, CancellationToken cancellationToken = default)
    {
        await _context.RefreshTokens.AddAsync(token, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return token;
    }

    public async Task<RefreshToken> UpdateAsync(RefreshToken token, CancellationToken cancellationToken = default)
    {
        _context.RefreshTokens.Update(token);
        await _context.SaveChangesAsync(cancellationToken);
        
        return token;
    }

    public async Task RemoveAsync(RefreshToken token, CancellationToken cancellationToken = default)
    {
        _context.RefreshTokens.Remove(token);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<RefreshToken?> GetAsync(string token, CancellationToken cancellationToken = default)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token, cancellationToken);
    }

    public async Task RemoveAllAsync(int userId, CancellationToken cancellationToken = default)
    {
        _context.RefreshTokens.RemoveRange(
            _context.RefreshTokens.Where(rt => rt.UserId == userId));
        await _context.SaveChangesAsync(cancellationToken);
    }
}