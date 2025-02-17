namespace SAX.Application.Features.Inventory.DTOs.Warehouse;

public class CreateWarehouseDto
{
    public string WarehouseName { get; set; } = string.Empty;
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
}