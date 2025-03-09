using SAX.Domain;

namespace SAX.Application.Features.Orders.DTOs;

public class OrderStatusHistoryDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime StatusDate { get; set; }
    public string? Notes { get; set; }
}