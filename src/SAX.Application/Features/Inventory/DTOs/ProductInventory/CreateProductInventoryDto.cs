namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class CreateProductInventoryDto
{
    public Guid ProductId { get; set; }
    public int QuantityOnHand { get; set; }
    public int QuantityAvailable { get; set; }
    public Guid WarehouseId { get; set; }
}