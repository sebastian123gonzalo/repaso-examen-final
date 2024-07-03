using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Domain.Model.Queries;
using si730ebu202217239.maintenance.Domain.Services;
using si730ebu202217239.maintenance.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202217239.maintenance.Application.Internal.QueryServices;

public class MaintenanceActivityQueryService(IMaintenanceActivityRepository maintenanceActivityRepository) : IMaintenanceActivityQueryService
{
    public async Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query)
    {
        return await maintenanceActivityRepository.FindByIdAsync(query.Id);
    }
    
}