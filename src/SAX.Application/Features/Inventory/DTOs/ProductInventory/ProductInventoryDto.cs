namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class ProductInventoryDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int QuantityOnHand { get; set; }
    public int QuantityAvailable { get; set; }
    public DateTime LastStockUpdate { get; set; }
    public Guid WarehouseId { get; set; }
}