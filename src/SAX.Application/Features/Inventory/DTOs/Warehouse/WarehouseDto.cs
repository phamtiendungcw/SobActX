using SAX.Application.Features.Customers.DTOs;

namespace SAX.Application.Features.Inventory.DTOs.Warehouse;

public class WarehouseDto
{
    public Guid WarehouseId { get; set; }
    public string WarehouseName { get; set; } = string.Empty;
    public AddressDto? Address { get; set; }
}