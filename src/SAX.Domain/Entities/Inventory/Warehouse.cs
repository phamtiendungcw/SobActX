using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Inventory;

public class Warehouse : BaseEntity
{
    public string WarehouseName { get; set; } = string.Empty;
    public int? AddressId { get; set; } // Foreign key to Address, nullable as address might be optional
    public Address? Address { get; set; } // Navigation property
    public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>(); // Navigation property
}