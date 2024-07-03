using si730ebu202217239.inventory.Domain.Model.Aggregates;

namespace si730ebu202217239.maintenance.Application.Internal.OutboundServices.ACL;

public interface IExternalProductService
{
    Task<Product?> FetchProductBySerialNumber(string serialNumber);
    Task<Product?> UpdateProductStatusBySerialNumber(string serialNumber, int status);
}