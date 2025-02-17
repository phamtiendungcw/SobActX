namespace SAX.Application.Features.Orders.DTOs.OrderItem;

public class OrderItemCreateDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}