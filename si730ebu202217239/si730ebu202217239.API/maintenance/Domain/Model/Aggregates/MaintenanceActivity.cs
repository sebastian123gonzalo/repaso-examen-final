using si730ebu202217239.maintenance.Domain.Model.Commands;
using si730ebu202217239.maintenance.Domain.Model.ValueObjects;

namespace si730ebu202217239.maintenance.Domain.Model.Aggregates;

public partial class MaintenanceActivity
{     
    public int Id { get;  }
    public string ProductSerialNumber { get; private set; }
    public string Summary { get; private set; }
    public string Description { get; private set; }
    public Result ActivityResult { get; private set; }
    
    
    public MaintenanceActivity()
    {
        ProductSerialNumber = string.Empty;
        Summary = string.Empty;
        Description = string.Empty;
        ActivityResult = new Result(0);
    }
    
     public MaintenanceActivity(CreateMaintenanceActivityCommand command)
     {
          ProductSerialNumber = command.ProductSerialNumber;
          Summary = command.Summary;
          Description = command.Description;
          ActivityResult = new Result(command.ActivityResult);
     }
     
    
}