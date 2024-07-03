using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Domain.Model.Commands;

namespace si730ebu202217239.maintenance.Domain.Services;

public interface IMaintenanceActivityCommandService
{
    public Task<MaintenanceActivity> Handle(CreateMaintenanceActivityCommand command);
}