using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Inventory;

public class ProductInventory : BaseEntity
{
    public Guid ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; }
    public int QuantityOnHand { get; set; }
    public int QuantityAvailable { get; set; }
    public DateTime LastStockUpdate { get; set; }
    public Guid WarehouseId { get; set; } // Foreign key to Warehouse
    public Warehouse? Warehouse { get; set; }
    public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
}