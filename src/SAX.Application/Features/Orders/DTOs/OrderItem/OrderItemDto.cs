using SAX.Application.Features.Products.DTOs.Product;

namespace SAX.Application.Features.Orders.DTOs.OrderItem;

public class OrderItemDto
{
    public Guid OrderItemId { get; set; }
    public ProductDto? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineItemTotal { get; set; }
}