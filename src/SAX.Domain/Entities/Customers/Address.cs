using SAX.Domain.Entities.Inventory;

namespace SAX.Domain.Entities.Customers;

public class Address : BaseEntity
{
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string Country { get; set; } = string.Empty;
    public ICollection<Customer> Customers { get; set; } = new List<Customer>(); // Navigation property
    public ICollection<Orders.Order> ShippingOrders { get; set; } = new List<Orders.Order>(); // Navigation property for shipping address
    public ICollection<Orders.Order> BillingOrders { get; set; } = new List<Orders.Order>();   // Navigation property for billing address
    public ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>(); // Navigation property for warehouses
}