namespace si730ebu202217239.maintenance.Domain.Model.Commands;

public record CreateMaintenanceActivityCommand(string ProductSerialNumber, string Summary, string Description, int ActivityResult);