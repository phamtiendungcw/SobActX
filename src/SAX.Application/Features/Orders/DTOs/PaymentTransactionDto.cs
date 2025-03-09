using SAX.Domain;

namespace SAX.Application.Features.Orders.DTOs;

public class PaymentTransactionDto
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public string? PaymentGatewayReference { get; set; }
}