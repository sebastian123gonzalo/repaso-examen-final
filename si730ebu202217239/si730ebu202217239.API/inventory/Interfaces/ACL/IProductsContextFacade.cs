using si730ebu202217239.inventory.Domain.Model.Aggregates;

namespace si730ebu202217239.inventory.Interfaces.ACL;

public interface IProductsContextFacade
{
    Task<Product?> FetchProductBySerialNumber(string serialNumber);
    Task<Product?> UpdateProductStatusBySerialNumber(string serialNumber, int status);
}