namespace SAX.Application.Features.Inventory.DTOs.ProductInventory;

public class ProductInventoryDetailsDto : ProductInventoryDto
{
    public string ProductName { get; set; } = string.Empty;
    public string WarehouseName { get; set; } = string.Empty;
}