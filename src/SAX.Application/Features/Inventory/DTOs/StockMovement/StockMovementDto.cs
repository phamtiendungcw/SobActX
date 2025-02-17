using SAX.Application.Features.Inventory.DTOs.ProductInventory;

namespace SAX.Application.Features.Inventory.DTOs.StockMovement;

public class StockMovementDto
{
    public Guid StockMovementId { get; set; }
    public ProductInventoryDto? ProductInventory { get; set; }
    public int QuantityChanged { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public DateTime MovementDate { get; set; }
    public string? Reason { get; set; }
}