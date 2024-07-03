namespace si730ebu202217239.inventory.Interfaces.Rest.Resources;

public record CreateProductResource(string Brand, string Model, string SerialNumber, string StatusDescription);