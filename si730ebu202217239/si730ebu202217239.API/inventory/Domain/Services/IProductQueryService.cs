using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Domain.Model.Queries;

namespace si730ebu202217239.inventory.Domain.Services;

public interface IProductQueryService
{
    public Task<Product?> Handle(GetProductByIdQuery query);
    public Task<Product?> Handle(GetProductBySerialNumberQuery query);
}