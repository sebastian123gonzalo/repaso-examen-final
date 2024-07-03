using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Domain.Model.Queries;

namespace si730ebu202217239.maintenance.Domain.Services;

public interface IMaintenanceActivityQueryService
{
    public Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query);
}