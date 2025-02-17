using SAX.Application.Features.Customers.DTOs;
using SAX.Application.Features.Customers.DTOs.Customer;
using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.DTOs.Order;

public class OrderDto
{
    public Guid OrderId { get; set; }
    public CustomerDto? Customer { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; } = string.Empty;
    public AddressDto? ShippingAddress { get; set; }
    public AddressDto? BillingAddress { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal? ShippingCost { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}