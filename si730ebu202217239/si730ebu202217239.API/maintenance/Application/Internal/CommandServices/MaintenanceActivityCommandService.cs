using si730ebu202217239.inventory.Domain.Services;
using si730ebu202217239.maintenance.Application.Internal.OutboundServices.ACL;
using si730ebu202217239.maintenance.Domain.Model.Aggregates;
using si730ebu202217239.maintenance.Domain.Model.Commands;
using si730ebu202217239.maintenance.Domain.Services;
using si730ebu202217239.maintenance.Infrastructure.Persistence.EFC.Repositories;
using si730ebu202217239.Shared.Domain.Repositories;

namespace si730ebu202217239.maintenance.Application.Internal.CommandServices;

public class MaintenanceActivityCommandService(IMaintenanceActivityRepository maintenanceActivityRepository, 
    IUnitOfWork unitOfWork, IExternalProductService externalProductService) : IMaintenanceActivityCommandService
{
    public async Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command)
    {
        var product = await externalProductService.FetchProductBySerialNumber(command.ProductSerialNumber);
        if (product is null) throw new Exception("Product Serial Number does not match any existing product");
        var maintenanceActivity = new MaintenanceActivity(command);
        try
        {
            await externalProductService.UpdateProductStatusBySerialNumber(command.ProductSerialNumber, command.ActivityResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"An error occurred while updating the product status from the maintenance activity result: {e.Message}");
        }
        try
        {
            await maintenanceActivityRepository.AddAsync(maintenanceActivity);
            await unitOfWork.CompleteAsync();
            return maintenanceActivity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"An error occurred while creating the maintenance activity: {e.Message}");
        }
    }
}