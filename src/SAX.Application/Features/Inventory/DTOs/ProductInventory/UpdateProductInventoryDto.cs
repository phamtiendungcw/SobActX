namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class UpdateProductInventoryDto
{
    public Guid ProductInventoryId { get; set; }
    public int? QuantityOnHand { get; set; }
    public int? QuantityAvailable { get; set; }
}