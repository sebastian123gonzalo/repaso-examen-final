using si730ebu202217239.Inventory.Domain.Model.Commands;
using si730ebu202217239.inventory.Interfaces.Rest.Resources;

namespace si730ebu202217239.inventory.Interfaces.Rest.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Brand, resource.Model, resource.SerialNumber, resource.StatusDescription);
    }
}