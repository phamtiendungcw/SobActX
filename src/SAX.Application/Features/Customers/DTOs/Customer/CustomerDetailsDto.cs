using SAX.Application.Features.Orders.DTOs;
using SAX.Application.Features.Orders.DTOs.Order;
using SAX.Application.Features.Products.DTOs;

namespace SAX.Application.Features.Customers.DTOs.Customer;

public class CustomerDetailsDto : CustomerDto
{
    public AddressDto? Address { get; set; }
    public List<OrderDto> Orders { get; set; } = new();
    public ShoppingCartDto? ShoppingCart { get; set; }
    public List<ProductReviewDto> ProductReviews { get; set; } = new();
}