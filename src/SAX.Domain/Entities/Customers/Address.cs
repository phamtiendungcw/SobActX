﻿using SAX.Domain.Entities.Inventory;
using SAX.Domain.Entities.Orders;

namespace SAX.Domain.Entities.Customers;

public class Address : BaseEntity
{
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string Country { get; set; } = string.Empty;
    public ICollection<Customer> Customers { get; set; } = new List<Customer>(); // One to many with Customer
    public ICollection<Order> ShippingOrders { get; set; } = new List<Order>();
    public ICollection<Order> BillingOrders { get; set; } = new List<Order>();
    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}