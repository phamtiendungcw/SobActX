using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.DTOs.Order;

public class OrderDetailsDto : OrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public List<OrderItemDto> OrderItems { get; set; } = new();
}