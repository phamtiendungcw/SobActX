using SAX.Application.Features.Orders.DTOs.OrderItem;

namespace SAX.Application.Features.Orders.DTOs.Order;

public class CreateOrderDto
{
    public Guid CustomerId { get; set; }
    public List<OrderItemCreateDto> OrderItems { get; set; } = new();
    public string ShippingAddressStreet { get; set; } = string.Empty;
    public string ShippingAddressCity { get; set; } = string.Empty;
    public string? ShippingAddressState { get; set; }
    public string? ShippingAddressZipCode { get; set; }
    public string ShippingAddressCountry { get; set; } = string.Empty;
    public string BillingAddressStreet { get; set; } = string.Empty;
    public string BillingAddressCity { get; set; } = string.Empty;
    public string? BillingAddressState { get; set; }
    public string? BillingAddressZipCode { get; set; }
    public string BillingAddressCountry { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
}