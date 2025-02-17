namespace SAX.Domain.Entities.Inventory;

public class ProductInventory
{
    public int ProductInventoryId { get; set; }
    public int ProductId { get; set; } // Foreign key to Product
    public Products.Product? Product { get; set; } // Navigation property
    public int QuantityOnHand { get; set; }
    public int QuantityAvailable { get; set; }
    public DateTime LastStockUpdate { get; set; }
    public int WarehouseId { get; set; } // Foreign key to Warehouse
    public Warehouse? Warehouse { get; set; } // Navigation property
    public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>(); // Navigation property
}