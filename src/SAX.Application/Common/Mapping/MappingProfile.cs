using AutoMapper;

using SAX.Application.Features.Content.DTOs.BlogPost;
using SAX.Application.Features.Content.DTOs.Category;
using SAX.Application.Features.Content.DTOs.Media;
using SAX.Application.Features.Content.DTOs.Page;
using SAX.Application.Features.Content.DTOs.Tag;
using SAX.Application.Features.Customers.DTOs;
using SAX.Application.Features.Customers.DTOs.Customer;
using SAX.Application.Features.Inventory.DTOs.ProductInventory;
using SAX.Application.Features.Inventory.DTOs.StockMovement;
using SAX.Application.Features.Inventory.DTOs.Warehouse;
using SAX.Application.Features.Logging.DTOs;
using SAX.Application.Features.Marketing.DTOs.Campaign;
using SAX.Application.Features.Marketing.DTOs.EmailCampaign;
using SAX.Application.Features.Marketing.DTOs.EmailTemplate;
using SAX.Application.Features.Marketing.DTOs.Segment;
using SAX.Application.Features.Orders.DTOs;
using SAX.Application.Features.Orders.DTOs.Order;
using SAX.Application.Features.Orders.DTOs.OrderItem;
using SAX.Application.Features.Products.DTOs;
using SAX.Application.Features.Products.DTOs.Product;
using SAX.Application.Features.Promotions.DTOs.Promotion;
using SAX.Application.Features.Promotions.DTOs.PromotionCategory;
using SAX.Application.Features.Promotions.DTOs.PromotionProduct;
using SAX.Application.Features.Users.DTOs.Permission;
using SAX.Application.Features.Users.DTOs.Role;
using SAX.Application.Features.Users.DTOs.RolePermission;
using SAX.Application.Features.Users.DTOs.User;
using SAX.Application.Features.Users.DTOs.UserRole;
using SAX.Domain.Entities.Content;
using SAX.Domain.Entities.Customers;
using SAX.Domain.Entities.Inventory;
using SAX.Domain.Entities.Logging;
using SAX.Domain.Entities.Marketing;
using SAX.Domain.Entities.Orders;
using SAX.Domain.Entities.Products;
using SAX.Domain.Entities.Promotions;
using SAX.Domain.Entities.Users;

namespace SAX.Application.Common.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Content Feature Mappings
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDetailsDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();

        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<Tag, TagDetailsDto>().ReverseMap();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();

        CreateMap<Page, PageDto>().ReverseMap();
        CreateMap<Page, PageDetailsDto>().ReverseMap();
        CreateMap<Page, CreatePageDto>().ReverseMap();
        CreateMap<Page, UpdatePageDto>().ReverseMap();

        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostDetailsDto>().ReverseMap();
        CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
        CreateMap<BlogPost, UpdateBlogPostDto>().ReverseMap();

        CreateMap<Media, MediaDto>().ReverseMap();
        CreateMap<Media, MediaDetailsDto>().ReverseMap();
        CreateMap<Media, CreateMediaDto>().ReverseMap();
        CreateMap<Media, UpdateMediaDto>().ReverseMap();

        // Customers Feature Mappings
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerDetailsDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

        CreateMap<Address, AddressDto>().ReverseMap();

        // Inventory Feature Mappings
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseDetailsDto>().ReverseMap();
        CreateMap<Warehouse, CreateWarehouseDto>().ReverseMap();
        CreateMap<Warehouse, UpdateWarehouseDto>().ReverseMap();

        CreateMap<ProductInventory, ProductInventoryDto>().ReverseMap();
        CreateMap<ProductInventory, ProductInventoryDetailsDto>().ReverseMap();
        CreateMap<ProductInventory, CreateProductInventoryDto>().ReverseMap();
        CreateMap<ProductInventory, UpdateProductInventoryDto>().ReverseMap();

        CreateMap<StockMovement, StockMovementDto>().ReverseMap();
        CreateMap<StockMovement, StockMovementDetailsDto>().ReverseMap();

        // Logging Feature Mappings
        CreateMap<LogEntry, LogEntryDto>().ReverseMap();
        CreateMap<LogEntry, LogEntryDetailsDto>().ReverseMap();

        // Marketing Feature Mappings
        CreateMap<Campaign, CampaignDto>().ReverseMap();
        CreateMap<Campaign, CampaignDetailsDto>().ReverseMap();
        CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
        CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();

        CreateMap<EmailCampaign, EmailCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, EmailCampaignDetailsDto>().ReverseMap();
        CreateMap<EmailCampaign, CreateEmailCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, UpdateEmailCampaignDto>().ReverseMap();

        CreateMap<Segment, SegmentDto>().ReverseMap();
        CreateMap<Segment, SegmentDetailsDto>().ReverseMap();
        CreateMap<Segment, CreateSegmentDto>().ReverseMap();
        CreateMap<Segment, UpdateSegmentDto>().ReverseMap();

        CreateMap<EmailTemplate, EmailTemplateDto>().ReverseMap();
        CreateMap<EmailTemplate, EmailTemplateDetailsDto>().ReverseMap();
        CreateMap<EmailTemplate, CreateEmailTemplateDto>().ReverseMap();
        CreateMap<EmailTemplate, UpdateEmailTemplateDto>().ReverseMap();

        // Orders Feature Mappings
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderDetailsDto>().ReverseMap();
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();

        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap(); // Map for nested creation

        CreateMap<OrderStatusHistory, OrderStatusHistoryDto>().ReverseMap();
        CreateMap<PaymentTransaction, PaymentTransactionDto>().ReverseMap();

        CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();

        // Products Feature Mappings
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductDetailsDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();

        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
        CreateMap<ProductAttribute, ProductAttributeDto>().ReverseMap();
        CreateMap<ProductAttributeValue, ProductAttributeValueDto>().ReverseMap();
        CreateMap<ProductReview, ProductReviewDto>().ReverseMap();

        // Promotions Feature Mappings
        CreateMap<Promotion, PromotionDto>().ReverseMap();
        CreateMap<Promotion, PromotionDetailsDto>().ReverseMap();
        CreateMap<Promotion, CreatePromotionDto>().ReverseMap();
        CreateMap<Promotion, UpdatePromotionDto>().ReverseMap();

        CreateMap<PromotionProduct, PromotionProductDto>().ReverseMap();
        CreateMap<PromotionProduct, PromotionProductDetailsDto>().ReverseMap();
        CreateMap<PromotionProduct, CreatePromotionProductDto>().ReverseMap();
        CreateMap<PromotionProduct, UpdatePromotionProductDto>().ReverseMap();

        CreateMap<PromotionCategory, PromotionCategoryDto>().ReverseMap();
        CreateMap<PromotionCategory, PromotionCategoryDetailsDto>().ReverseMap();
        CreateMap<PromotionCategory, CreatePromotionCategoryDto>().ReverseMap();
        CreateMap<PromotionCategory, UpdatePromotionCategoryDto>().ReverseMap();

        // Users Feature Mappings
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserDetailsDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();

        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Role, RoleDetailsDto>().ReverseMap();
        CreateMap<Role, CreateRoleDto>().ReverseMap();
        CreateMap<Role, UpdateRoleDto>().ReverseMap();

        CreateMap<Permission, PermissionDto>().ReverseMap();
        CreateMap<Permission, PermissionDetailsDto>().ReverseMap();
        CreateMap<Permission, CreatePermissionDto>().ReverseMap();
        CreateMap<Permission, UpdatePermissionDto>().ReverseMap();

        CreateMap<UserRole, UserRoleDto>().ReverseMap();
        CreateMap<UserRole, UserRoleDetailsDto>().ReverseMap();
        CreateMap<UserRole, CreateUserRoleDto>().ReverseMap();
        CreateMap<UserRole, UpdateUserRoleDto>().ReverseMap();

        CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionDetailsDto>().ReverseMap();
        CreateMap<RolePermission, CreateRolePermissionDto>().ReverseMap();
        CreateMap<RolePermission, UpdateRolePermissionDto>().ReverseMap();
    }
}