using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Orders.DTOs;

public class ShoppingCartItemDto
{
    public Guid ShoppingCartItemId { get; set; }
    public ProductDto? Product { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }
}