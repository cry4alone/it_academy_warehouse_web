using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;

namespace Storage.DAL.Repositories;

public class MeltRepository
{
    private readonly WarehouseContext _context;
    
    public MeltRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<List<Melt>> GetAllAsync()
    {
        return await _context.Melts.ToListAsync();
    }
}