namespace si730ebu202217239.maintenance.Interfaces.Rest.Resources;

public record MaintenanceActivityResource(int Id, string ProductSerialNumber, string Summary, string Description, int ActivityResult);