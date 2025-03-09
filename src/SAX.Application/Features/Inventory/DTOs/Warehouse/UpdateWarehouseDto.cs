namespace SAX.Application.Features.Inventory.DTOs.Warehouse;

public class UpdateWarehouseDto
{
    public Guid Id { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public Guid? AddressId { get; set; }
}