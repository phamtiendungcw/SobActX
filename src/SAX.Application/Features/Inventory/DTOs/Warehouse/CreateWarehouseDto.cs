namespace SAX.Application.Features.Inventory.DTOs.Warehouse;

public class CreateWarehouseDto
{
    public string WarehouseName { get; set; } = string.Empty;
    public Guid? AddressId { get; set; }
}