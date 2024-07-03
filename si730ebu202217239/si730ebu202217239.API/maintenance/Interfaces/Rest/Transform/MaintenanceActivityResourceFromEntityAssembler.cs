using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Interfaces.Rest.Resources;

namespace si730ebu202217239.maintenance.Interfaces.Rest.Transform;

public class MaintenanceActivityResourceFromEntityAssembler
{
    public static MaintenanceActivityResource ToResourceFromEntity(MaintenanceActivity entity)
    {
        return new MaintenanceActivityResource
        (
            entity.Id,
            entity.ProductSerialNumber,
            entity.Summary,
            entity.Description,
            entity.ActivityResult.ActivityResult
            
        );
    }
}