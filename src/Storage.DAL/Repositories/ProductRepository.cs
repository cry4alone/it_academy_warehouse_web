using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WarehouseContext _context;

    public ProductRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken: cancellationToken);
    }

    public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.Name == name, cancellationToken: cancellationToken);
    }
}