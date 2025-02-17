namespace SAX.Application.Features.Orders.DTOs;

public class OrderStatusHistoryDto
{
    public Guid OrderStatusHistoryId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime StatusDate { get; set; }
    public string? Notes { get; set; }
}