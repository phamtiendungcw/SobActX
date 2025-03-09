namespace SAX.Application.Features.Orders.DTOs;

public class ShoppingCartItemDto
{
    public Guid Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }
}