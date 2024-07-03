using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.Inventory.Domain.Model.Commands;

namespace si730ebu202217239.inventory.Domain.Services;

public interface IProductCommandService
{
    public Task<Product?> Handle(CreateProductCommand command);
    public Task<Product?> Handle(UpdateProductStatusBySerialNumberCommand command);
}