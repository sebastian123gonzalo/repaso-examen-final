using Microsoft.EntityFrameworkCore;
using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Domain.Repositories;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202217239.inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public async Task<Product?> FindBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(p => p.SerialNumber == serialNumber);
    }
} 