namespace SAX.Domain.Entities.Inventory;

public class StockMovement : BaseEntity
{
    public int ProductInventoryId { get; set; } // Foreign key to ProductInventory
    public ProductInventory? ProductInventory { get; set; } // Navigation property
    public int QuantityChanged { get; set; }
    public string MovementType { get; set; } = string.Empty; // e.g., "Inbound", "Outbound", "Adjustment"
    public DateTime MovementDate { get; set; }
    public string? Reason { get; set; }
}