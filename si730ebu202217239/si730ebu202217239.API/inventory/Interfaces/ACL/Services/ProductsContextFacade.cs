using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.Inventory.Domain.Model.Commands;
using si730ebu202217239.inventory.Domain.Model.Queries;
using si730ebu202217239.inventory.Domain.Services;

namespace si730ebu202217239.inventory.Interfaces.ACL.Services;

public class ProductsContextFacade(IProductCommandService productCommandService, IProductQueryService productQueryService) : IProductsContextFacade
{
    public async Task<Product?> FetchProductBySerialNumber(string serialNumber)
    {
        var getProductBySerialNumberQuery = new GetProductBySerialNumberQuery(serialNumber);
        var product = await productQueryService.Handle(getProductBySerialNumberQuery);
        return product;
    }

    public async Task<Product?> UpdateProductStatusBySerialNumber(string serialNumber, int status)
    {
        var updateProductStatusBySerialNumberCommand = new UpdateProductStatusBySerialNumberCommand(serialNumber, status);
        return await productCommandService.Handle(updateProductStatusBySerialNumberCommand);
    }
}
