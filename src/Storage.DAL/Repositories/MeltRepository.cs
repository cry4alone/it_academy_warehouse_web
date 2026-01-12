using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

/// <inheritdoc cref="IMeltRepository" />
public class MeltRepository : IMeltRepository
{
    private readonly WarehouseContext _context;

    /// <summary>
    /// Создаёт экземпляр <see cref="MeltRepository"/>, использующий указанный контекст хранилища.
    /// </summary>
    /// <param name="context">Экземпляр <see cref="WarehouseContext"/>, через который выполняются операции с БД.</param>
    /// <exception cref="ArgumentNullException">Если <paramref name="context"/> равен <c>null</c>.</exception>
    public MeltRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Melt>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Melts
            .Include(m => m.Brand)
            .Include(m => m.Product)
            .Include(m => m.Specification)
            .Include(m => m.MeltStatus)
            .Include(m => m.Certificate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Melt?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Melts
            .Include(m => m.Brand)
            .Include(m => m.Product)
            .Include(m => m.Specification)
            .Include(m => m.MeltStatus)
            .Include(m => m.Certificate)
            .FirstOrDefaultAsync(m => m.MeltId == id, cancellationToken);
    }

    public async Task<Melt> CreateAsync(Melt melt, CancellationToken cancellationToken = default)
    {
        _context.Melts.Add(melt);
        await _context.SaveChangesAsync(cancellationToken);
        var created = await GetByIdAsync(melt.MeltId, cancellationToken);
        return created ?? melt;
    }

    public async Task<Melt> UpdateAsync(Melt melt, CancellationToken cancellationToken = default)
    {
        _context.Melts.Update(melt);
        await _context.SaveChangesAsync(cancellationToken);
        return melt;
    }
}