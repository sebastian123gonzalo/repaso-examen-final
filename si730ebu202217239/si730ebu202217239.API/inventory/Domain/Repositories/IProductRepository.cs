using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.Shared.Domain.Repositories;

namespace si730ebu202217239.inventory.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> FindBySerialNumberAsync(string serialNumber);    
}