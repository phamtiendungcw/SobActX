using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Orders.DTOs;

public class ShoppingCartDto
{
    public Guid ShoppingCartId { get; set; }
    public CustomerDto? Customer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
}