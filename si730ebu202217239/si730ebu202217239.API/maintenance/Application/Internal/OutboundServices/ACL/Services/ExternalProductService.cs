using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Interfaces.ACL;

namespace si730ebu202217239.maintenance.Application.Internal.OutboundServices.ACL.Services;

public class ExternalProductService(IProductsContextFacade productsContextFacade) : IExternalProductService
{
    public async Task<Product?> FetchProductBySerialNumber(string serialNumber)
    {
        return await productsContextFacade.FetchProductBySerialNumber(serialNumber);
    }
    
    public async Task<Product?> UpdateProductStatusBySerialNumber(string serialNumber, int status)
    {
        return await productsContextFacade.UpdateProductStatusBySerialNumber(serialNumber, status);
    }
}
