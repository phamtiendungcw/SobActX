﻿using SAX.Application.Features.Orders.DTOs.OrderItem;
using SAX.Domain;

namespace SAX.Application.Features.Orders.DTOs.Order;

public class CreateOrderDto
{
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public Guid? ShippingAddressId { get; set; }
    public Guid? BillingAddressId { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal? DiscountAmount { get; set; }
    public decimal? ShippingCost { get; set; }
    public List<CreateOrderItemDto> OrderItems { get; set; } = new();
}