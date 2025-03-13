using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using SAX.Application.Common.Mapping;
using SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;
using SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;
using SAX.Application.Features.Content.Commands.BlogPostTag.CreateBlogPostTag;
using SAX.Application.Features.Content.Commands.BlogPostTag.UpdateBlogPostTag;
using SAX.Application.Features.Content.Commands.Category.CreateCategory;
using SAX.Application.Features.Content.Commands.Category.UpdateCategory;
using SAX.Application.Features.Content.Commands.Media.CreateMedia;
using SAX.Application.Features.Content.Commands.Media.UpdateMedia;
using SAX.Application.Features.Content.Commands.Page.CreatePage;
using SAX.Application.Features.Content.Commands.Page.UpdatePage;
using SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;
using SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;
using SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;
using SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;
using SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;
using SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;
using SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;
using SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;
using SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;
using SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;
using SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;
using SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;
using SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;
using SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;
using SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;
using SAX.Application.Features.Orders.Commands.Order.CreateOrder;
using SAX.Application.Features.Orders.Commands.Order.UpdateOrder;
using SAX.Application.Features.Products.Commands.Product.CreateProduct;
using SAX.Application.Features.Products.Commands.Product.UpdateProduct;
using SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;
using SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;
using SAX.Application.Features.Users.Commands.User.CreateUser;
using SAX.Application.Features.Users.Commands.User.UpdateUser;

namespace SAX.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        #region Subscribe Validators

        // Content Feature Validators
        services.AddScoped<IValidator<CreateBlogPostCommand>, CreateBlogPostCommandValidator>();
        services.AddScoped<IValidator<UpdateBlogPostCommand>, UpdateBlogPostCommandValidator>();
        services.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidator>();
        services.AddScoped<IValidator<UpdateCategoryCommand>, UpdateCategoryCommandValidator>();
        services.AddScoped<IValidator<CreateMediaCommand>, CreateMediaCommandValidator>();
        services.AddScoped<IValidator<UpdateMediaCommand>, UpdateMediaCommandValidator>();
        services.AddScoped<IValidator<CreatePageCommand>, CreatePageCommandValidator>();
        services.AddScoped<IValidator<UpdatePageCommand>, UpdatePageCommandValidator>();
        services.AddScoped<IValidator<CreateBlogPostTagCommand>, CreateBlogPostTagCommandValidator>();
        services.AddScoped<IValidator<UpdateBlogPostTagCommand>, UpdateBlogPostTagCommandValidator>();

        // Customers Feature Validators
        services.AddScoped<IValidator<CreateCustomerCommand>, CreateCustomerCommandValidator>();
        services.AddScoped<IValidator<UpdateCustomerCommand>, UpdateCustomerCommandValidator>();
        //services.AddScoped<IValidator<CreateAddressCommand>, CreateAddressCommandValidator>();
        //services.AddScoped<IValidator<UpdateAddressCommand>, UpdateAddressCommandValidator>();

        // Inventory Feature Validators
        services.AddScoped<IValidator<CreateWarehouseCommand>, CreateWarehouseCommandValidator>();
        services.AddScoped<IValidator<UpdateWarehouseCommand>, UpdateWarehouseCommandValidator>();
        services.AddScoped<IValidator<CreateProductInventoryCommand>, CreateProductInventoryCommandValidator>();
        services.AddScoped<IValidator<UpdateProductInventoryCommand>, UpdateProductInventoryCommandValidator>();
        services.AddScoped<IValidator<CreateStockMovementCommand>, CreateStockMovementCommandValidator>();
        //services.AddScoped<IValidator<UpdateStockMovementCommand>, UpdateStockMovementCommandValidator>();

        // Logging Feature Validators
        //services.AddScoped<IValidator<LogEntryCommand>, LogEntryDtoValidator>();

        // Marketing Feature Validators
        services.AddScoped<IValidator<CreateCampaignCommand>, CreateCampaignCommandValidator>();
        services.AddScoped<IValidator<UpdateCampaignCommand>, UpdateCampaignCommandValidator>();
        services.AddScoped<IValidator<CreateEmailCampaignCommand>, CreateEmailCampaignCommandValidator>();
        services.AddScoped<IValidator<UpdateEmailCampaignCommand>, UpdateEmailCampaignCommandValidator>();
        services.AddScoped<IValidator<CreateEmailTemplateCommand>, CreateEmailTemplateCommandValidator>();
        services.AddScoped<IValidator<UpdateEmailTemplateCommand>, UpdateEmailTemplateCommandValidator>();
        services.AddScoped<IValidator<CreateSegmentCommand>, CreateSegmentCommandValidator>();
        services.AddScoped<IValidator<UpdateSegmentCommand>, UpdateSegmentCommandValidator>();

        // Orders Feature Validators
        services.AddScoped<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
        services.AddScoped<IValidator<UpdateOrderCommand>, UpdateOrderCommandValidator>();
        //services.AddScoped<IValidator<CreateOrderItemCommand>, CreateOrderItemCommandValidator>();
        //services.AddScoped<IValidator<UpdateOrderItemCommand>, UpdateOrderItemCommandValidator>();
        //services.AddScoped<IValidator<CreateOrderStatusHistoryCommand>, CreateOrderStatusHistoryCommandValidator>();
        //services.AddScoped<IValidator<UpdateOrderStatusHistoryCommand>, UpdateOrderStatusHistoryCommandValidator>();
        //services.AddScoped<IValidator<CreatePaymentTransactionCommand>, CreatePaymentTransactionCommandValidator>();
        //services.AddScoped<IValidator<UpdatePaymentTransactionCommand>, UpdatePaymentTransactionCommandValidator>();
        //services.AddScoped<IValidator<CreateShoppingCartCommand>, CreateShoppingCartCommandValidator>();
        //services.AddScoped<IValidator<UpdateShoppingCartCommand>, UpdateShoppingCartCommandValidator>();
        //services.AddScoped<IValidator<CreateShoppingCartItemCommand>, CreateShoppingCartItemCommandValidator>();
        //services.AddScoped<IValidator<UpdateShoppingCartItemCommand>, UpdateShoppingCartItemCommandValidator>();

        // Products Feature Validators
        services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
        services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();
        //services.AddScoped<IValidator<CreateProductCategoryCommand>, CreateProductCategoryCommandValidator>();
        //services.AddScoped<IValidator<UpdateProductCategoryCommand>, UpdateProductCategoryCommandValidator>();
        //services.AddScoped<IValidator<CreateProductAttributeCommand>, CreateProductAttributeCommandValidator>();
        //services.AddScoped<IValidator<UpdateProductAttributeCommand>, UpdateProductAttributeCommandValidator>();
        //services.AddScoped<IValidator<CreateProductReviewCommand>, CreateProductReviewCommandValidator>();
        //services.AddScoped<IValidator<UpdateProductReviewCommand>, UpdateProductReviewCommandValidator>();

        // Promotions Feature Validators
        services.AddScoped<IValidator<CreatePromotionCommand>, CreatePromotionCommandValidator>();
        services.AddScoped<IValidator<UpdatePromotionCommand>, UpdatePromotionCommandValidator>();
        //services.AddScoped<IValidator<CreatePromotionCategoryCommand>, CreatePromotionCategoryCommandValidator>();
        //services.AddScoped<IValidator<UpdatePromotionCategoryCommand>, UpdatePromotionCategoryCommandValidator>();
        //services.AddScoped<IValidator<CreatePromotionProductCommand>, CreatePromotionProductCommandValidator>();
        //services.AddScoped<IValidator<UpdatePromotionProductCommand>, UpdatePromotionProductCommandValidator>();

        // Users Feature Validators
        //services.AddScoped<IValidator<CreatePermissionCommand>, CreatePermissionCommandValidator>();
        //services.AddScoped<IValidator<UpdatePermissionCommand>, UpdatePermissionCommandValidator>();
        //services.AddScoped<IValidator<CreateRoleCommand>, CreateRoleCommandValidator>();
        //services.AddScoped<IValidator<UpdateRoleCommand>, UpdateRoleCommandValidator>();
        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
        //services.AddScoped<IValidator<CreateUserRoleCommand>, CreateUserRoleCommandValidator>();
        //services.AddScoped<IValidator<UpdateUserRoleCommand>, UpdateUserRoleCommandValidator>();

        #endregion

        return services;
    }
}