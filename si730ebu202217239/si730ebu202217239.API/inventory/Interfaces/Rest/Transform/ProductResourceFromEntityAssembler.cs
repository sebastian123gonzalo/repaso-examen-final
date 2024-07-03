using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.inventory.Interfaces.Rest.Resources;

namespace si730ebu202217239.inventory.Interfaces.Rest.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(entity.Id, entity.Brand, entity.Model, entity.SerialNumber, entity.StatusDescription.StatusDescription);
    }
}