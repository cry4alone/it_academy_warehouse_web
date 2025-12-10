using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

public class CertificateRepository : ICertificatesRepository
{
    public readonly WarehouseContext _context;
    
    public CertificateRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Certificate>> GetAllAsync()
    {
        return await _context.Certificates
            .Include(c => c.ControlScheme)
                .ThenInclude(cs => cs.Specification)
            .Include(c => c.Warehouse)
            .Include(c => c.Melts)
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<Certificate?> GetByIdAsync(int id)
    {
        return await _context.Certificates
            .Include(c => c.ControlScheme)
            .ThenInclude(cs => cs.Specification)
            .Include(c => c.Warehouse)
            .Include(c => c.Melts)
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.CertificateId == id);
    }

    public async Task<Certificate> CreateAsync(Certificate certificate)
    {
        _context.Certificates.Add(certificate);
        await _context.SaveChangesAsync();
        return certificate;
    }

    public async Task<Certificate> UpdateAsync(Certificate certificate)
    {
        _context.Certificates.Update(certificate);
        await _context.SaveChangesAsync();
        return certificate;
    }
}