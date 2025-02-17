using SAX.Application.Features.Inventory.DTOs.StockMovement;

namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class ProductInventoryDetailsDto : ProductInventoryDto
{
    public List<StockMovementDto> StockMovements { get; set; } = new();
}