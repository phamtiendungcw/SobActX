namespace SAX.Application.Features.Orders.DTOs;

public class ShoppingCartDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
}