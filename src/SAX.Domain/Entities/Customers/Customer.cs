﻿using SAX.Domain.Entities.Orders;
using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Customers;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid? AddressId { get; set; } // Foreign key to Address, nullable as address might be optional
    public Address? Address { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    public ShoppingCart? ShoppingCart { get; set; } // One-to-One
}