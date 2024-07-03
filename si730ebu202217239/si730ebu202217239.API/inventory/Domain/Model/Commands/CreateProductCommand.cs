namespace si730ebu202217239.Inventory.Domain.Model.Commands;

public record CreateProductCommand(string Brand, string Model, string SerialNumber, string StatusDescription);