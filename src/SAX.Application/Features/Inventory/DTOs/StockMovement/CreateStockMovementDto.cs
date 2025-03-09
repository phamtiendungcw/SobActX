using SAX.Domain;

namespace SAX.Application.Features.Inventory.DTOs.StockMovement;

public class CreateStockMovementDto
{
    public Guid ProductInventoryId { get; set; }
    public int QuantityChanged { get; set; }
    public MovementType MovementType { get; set; }
    public DateTime MovementDate { get; set; }
    public string? Reason { get; set; }
}