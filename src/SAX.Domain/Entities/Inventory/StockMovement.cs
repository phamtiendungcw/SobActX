namespace SAX.Domain.Entities.Inventory;

public class StockMovement : BaseEntity
{
    public Guid ProductInventoryId { get; set; } // Foreign key to ProductInventory
    public ProductInventory? ProductInventory { get; set; }
    public int QuantityChanged { get; set; }
    public MovementType MovementType { get; set; } // Enum MovementType {  Inbound, Outbound, Adjustment }
    public DateTime MovementDate { get; set; }
    public string? Reason { get; set; }
}