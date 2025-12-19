using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using System.Threading;

namespace Storage.DAL.Repositories;

public class CertificateRepository : ICertificatesRepository
{
    public readonly WarehouseContext _context;
    
    public CertificateRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Certificate>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Certificates
            .Include(c => c.ControlScheme)
                .ThenInclude(cs => cs.Specification)
            .Include(c => c.Warehouse)
            .Include(c => c.Melts)
            .Include(c => c.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<Certificate?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Certificates
            .Include(c => c.ControlScheme)
            .ThenInclude(cs => cs.Specification)
            .Include(c => c.Warehouse)
            .Include(c => c.Melts)
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.CertificateId == id, cancellationToken);
    }

    public async Task<Certificate> CreateAsync(Certificate certificate, CancellationToken cancellationToken = default)
    {
        _context.Certificates.Add(certificate);
        await _context.SaveChangesAsync(cancellationToken);
        var created = await GetByIdAsync(certificate.CertificateId, cancellationToken);
        return created ?? certificate;
    }

    public async Task<Certificate> UpdateAsync(Certificate certificate, CancellationToken cancellationToken = default)
    {
        _context.Certificates.Update(certificate);
        await _context.SaveChangesAsync(cancellationToken);
        return certificate;
    }
}