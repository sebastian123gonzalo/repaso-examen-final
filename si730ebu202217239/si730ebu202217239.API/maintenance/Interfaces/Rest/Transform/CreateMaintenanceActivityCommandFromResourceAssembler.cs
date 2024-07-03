using si730ebu202217239.maintenance.Domain.Model.Commands;
using si730ebu202217239.maintenance.Interfaces.Rest.Resources;

namespace si730ebu202217239.maintenance.Interfaces.Rest.Transform;

public static class CreateMaintenanceActivityCommandFromResourceAssembler
{
    public static CreateMaintenanceActivityCommand ToCommandFromResource(CreateMaintenanceActivityResource resource)
    {
        return new CreateMaintenanceActivityCommand
        (
            resource.ProductSerialNumber, 
            resource.Summary,
            resource.Description, 
            resource.ActivityResult
        );
    }
}