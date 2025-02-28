using Microsoft.EntityFrameworkCore;

using SAX.Domain.Entities;
using SAX.Domain.Entities.Content;
using SAX.Domain.Entities.Customers;
using SAX.Domain.Entities.Inventory;
using SAX.Domain.Entities.Logging;
using SAX.Domain.Entities.Marketing;
using SAX.Domain.Entities.Orders;
using SAX.Domain.Entities.Products;
using SAX.Domain.Entities.Promotions;
using SAX.Domain.Entities.Users;

namespace SAX.Persistence.DatabaseContext;

public class SobActXDatabaseContext : DbContext
{
    public SobActXDatabaseContext(DbContextOptions<SobActXDatabaseContext> options) : base(options)
    {
    }

    // --- DbSet cho Content Feature ---
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Page> Pages { get; set; } = null!;
    public DbSet<BlogPost> BlogPosts { get; set; } = null!;
    public DbSet<Media> Media { get; set; } = null!;

    // --- DbSet cho Customers Feature ---
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    // --- DbSet cho Inventory Feature ---
    public DbSet<Warehouse> Warehouses { get; set; } = null!;
    public DbSet<ProductInventory> ProductInventories { get; set; } = null!;
    public DbSet<StockMovement> StockMovements { get; set; } = null!;

    // --- DbSet cho Logging Feature ---
    public DbSet<LogEntry> LogEntries { get; set; } = null!;

    // --- DbSet cho Marketing Feature ---
    public DbSet<Campaign> Campaigns { get; set; } = null!;
    public DbSet<EmailCampaign> EmailCampaigns { get; set; } = null!;
    public DbSet<Segment> Segments { get; set; } = null!;
    public DbSet<EmailTemplate> EmailTemplates { get; set; } = null!;

    // --- DbSet cho Orders Feature ---
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; } = null!;
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; } = null!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

    // --- DbSet cho Products Feature ---
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
    public DbSet<ProductBrand> ProductBrands { get; set; } = null!;
    public DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;
    public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; } = null!;
    public DbSet<ProductReview> ProductReviews { get; set; } = null!;

    // --- DbSet cho Promotions Feature ---
    public DbSet<Promotion> Promotions { get; set; } = null!;
    public DbSet<PromotionProduct> PromotionProducts { get; set; } = null!;
    public DbSet<PromotionCategory> PromotionCategories { get; set; } = null!;

    // --- DbSet cho Users Feature ---
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SobActXDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.IsActive = true;
                entry.Entity.IsDeleted = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}