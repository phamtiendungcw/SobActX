namespace SAX.Application.Features.Orders.DTOs.Order;

public class OrderDetailsDto : OrderDto
{
    public List<OrderStatusHistoryDto> OrderStatusHistories { get; set; } = new();
    public List<PaymentTransactionDto> PaymentTransactions { get; set; } = new();
}