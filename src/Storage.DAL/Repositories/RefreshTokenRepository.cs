using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly WarehouseContext _context;

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

    public async Task RemoveAllAsync(CancellationToken cancellationToken = default)
    {
        _context.RefreshTokens.RemoveRange(_context.RefreshTokens);
        await _context.SaveChangesAsync(cancellationToken);
    }
}