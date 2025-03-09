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

public class SaxDbContext : DbContext
{
#pragma warning disable CS8618

    public SaxDbContext(DbContextOptions<SaxDbContext> options) : base(options)
    {
    }

#pragma warning restore CS8618

    // --- DbSet cho Content Feature ---
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<BlogPostTag> BlogPostsTags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Tag> Tags { get; set; }

    // --- DbSet cho Customers Feature ---
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }

    // --- DbSet cho Inventory Feature ---
    public DbSet<ProductInventory> ProductInventories { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    // --- DbSet cho Logging Feature ---
    public DbSet<LogEntry> LogEntries { get; set; }

    // --- DbSet cho Marketing Feature ---
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<EmailCampaign> EmailCampaigns { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<Segment> Segments { get; set; }

    // --- DbSet cho Orders Feature ---
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
    public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    // --- DbSet cho Products Feature ---
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }

    // --- DbSet cho Promotions Feature ---
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionCategory> PromotionsCategories { get; set; }
    public DbSet<PromotionProduct> PromotionsProducts { get; set; }

    // --- DbSet cho Users Feature ---
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolesPermissions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UsersRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaxDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.IsActive = true;
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.IsActive = false;
                    entry.State = EntityState.Modified;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}