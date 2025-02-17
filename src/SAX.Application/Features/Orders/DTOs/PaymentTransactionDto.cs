namespace SAX.Application.Features.Orders.DTOs;

public class PaymentTransactionDto
{
    public Guid PaymentTransactionId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public string? PaymentGatewayReference { get; set; }
}