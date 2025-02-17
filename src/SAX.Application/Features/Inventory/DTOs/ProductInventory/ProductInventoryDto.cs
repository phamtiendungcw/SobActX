using SAX.Application.Features.Inventory.DTOs.Warehouse;
using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class ProductInventoryDto
{
    public Guid ProductInventoryId { get; set; }
    public ProductDto? Product { get; set; }
    public int QuantityOnHand { get; set; }
    public int QuantityAvailable { get; set; }
    public DateTime LastStockUpdate { get; set; }
    public WarehouseDto? Warehouse { get; set; }
}