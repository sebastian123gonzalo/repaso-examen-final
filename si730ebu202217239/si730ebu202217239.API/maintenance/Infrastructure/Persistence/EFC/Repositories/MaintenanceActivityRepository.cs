using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202217239.maintenance.Infrastructure.Persistence.EFC.Repositories;

public class MaintenanceActivityRepository(AppDbContext context) : BaseRepository<MaintenanceActivity>(context), IMaintenanceActivityRepository
{
    
}