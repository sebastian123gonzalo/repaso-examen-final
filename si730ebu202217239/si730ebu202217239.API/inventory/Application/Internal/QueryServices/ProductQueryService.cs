using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Domain.Model.Queries;
using si730ebu202217239.inventory.Domain.Repositories;
using si730ebu202217239.inventory.Domain.Services;

namespace si730ebu202217239.inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.Id);
    }
    
    public async Task<Product?> Handle(GetProductBySerialNumberQuery query)
    {
        return await productRepository.FindBySerialNumberAsync(query.SerialNumber);
    }
    
}