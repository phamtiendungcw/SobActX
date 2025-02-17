namespace SAX.Application.Features.Orders.DTOs.Order;

public class UpdateOrderDto
{
    public Guid OrderId { get; set; }
    public string? OrderStatus { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal? ShippingCost { get; set; }
}