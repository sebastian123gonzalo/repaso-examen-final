namespace si730ebu202217239.Inventory.Domain.Model.Commands;

public record UpdateProductStatusBySerialNumberCommand(string SerialNumber, int Status);