using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.DTOs.Warehouse;

public class WarehouseDetailsDto : WarehouseDto
{
    public List<ProductInventoryDto> ProductInventories { get; set; } = new();
}