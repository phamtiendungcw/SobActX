using SAX.Domain.Entities.Customers;

namespace SAX.Domain.Entities.Inventory;

public class Warehouse : BaseEntity
{
    public string WarehouseName { get; set; } = string.Empty;
    public Guid? AddressId { get; set; } // Foreign key to Address, nullable as address might be optional
    public Address? Address { get; set; }
    public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}