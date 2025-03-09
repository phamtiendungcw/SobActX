using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Contracts.Persistence.Repositories.Logging;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Persistence.DatabaseContext;
using SAX.Persistence.Repositories;
using SAX.Persistence.Repositories.Content;
using SAX.Persistence.Repositories.Customers;
using SAX.Persistence.Repositories.Inventory;
using SAX.Persistence.Repositories.Logging;
using SAX.Persistence.Repositories.Marketing;
using SAX.Persistence.Repositories.Orders;
using SAX.Persistence.Repositories.Products;
using SAX.Persistence.Repositories.Promotions;
using SAX.Persistence.Repositories.Users;

namespace SAX.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SaxDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SobActXDatabaseConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Content
        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
        services.AddScoped<IBlogPostTagRepository, BlogPostTagRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMediaRepository, MediaRepository>();
        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        // Customers
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        // Inventory
        services.AddScoped<IProductInventoryRepository, ProductInventoryRepository>();
        services.AddScoped<IStockMovementRepository, StockMovementRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        // Logging
        services.AddScoped<ILogEntryRepository, LogEntryRepository>();

        // Marketing
        services.AddScoped<ICampaignRepository, CampaignRepository>();
        services.AddScoped<IEmailCampaignRepository, EmailCampaignRepository>();
        services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
        services.AddScoped<ISegmentRepository, SegmentRepository>();

        // Order
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderStatusHistoryRepository, OrderStatusHistoryRepository>();
        services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
        services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
        services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

        // Products
        services.AddScoped<IProductAttributeRepository, ProductAttributeRepository>();
        services.AddScoped<IProductAttributeValueRepository, ProductAttributeValueRepository>();
        services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductReviewRepository, ProductReviewRepository>();

        // Promotions
        services.AddScoped<IPromotionCategoryRepository, PromotionCategoryRepository>();
        services.AddScoped<IPromotionProductRepository, PromotionProductRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();

        // Users
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        return services;
    }
}