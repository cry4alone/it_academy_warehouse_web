using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

public class MeltRepository : IMeltRepository
{
    private readonly WarehouseContext _context;

    public MeltRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Melt>> GetAllAsync()
    {
        return await _context.Melts
            .Include(m => m.Brand)
            .Include(m => m.Product)
            .Include(m => m.Specification)
            .Include(m => m.MeltStatus)
            .Include(m => m.Certificate)
            .ToListAsync();
    }

    public async Task<Melt?> GetByIdAsync(int id)
    {
        return await _context.Melts
            .Include(m => m.Brand)
            .Include(m => m.Product)
            .Include(m => m.Specification)
            .Include(m => m.MeltStatus)
            .Include(m => m.Certificate)
            .FirstOrDefaultAsync(m => m.MeltId == id);
    }

    public async Task<Melt> CreateAsync(Melt melt)
    {
        _context.Melts.Add(melt);
        await _context.SaveChangesAsync();
        var created = await GetByIdAsync(melt.MeltId);
        return created ?? melt;
    }

    public async Task<Melt> UpdateAsync(Melt melt)
    {
        _context.Melts.Update(melt);
        await _context.SaveChangesAsync();
        return melt;
    }
}