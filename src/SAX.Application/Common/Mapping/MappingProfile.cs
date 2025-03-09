using AutoMapper;

using SAX.Application.Features.Content.DTOs.BlogPost;
using SAX.Application.Features.Content.DTOs.BlogPostTag;
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
using SAX.Application.Features.Products.DTOs.ProductReview;
using SAX.Application.Features.Promotions.DTOs;
using SAX.Application.Features.Promotions.DTOs.Promotion;
using SAX.Application.Features.Users.DTOs;
using SAX.Application.Features.Users.DTOs.Permission;
using SAX.Application.Features.Users.DTOs.Role;
using SAX.Application.Features.Users.DTOs.User;
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
        // Content
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostDetailsDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : null))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
            .ReverseMap();
        CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
        CreateMap<BlogPost, UpdateBlogPostDto>().ReverseMap();

        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDetailsDto>().ReverseMap();
        // Create/Update DTOs

        CreateMap<Page, PageDto>().ReverseMap();
        CreateMap<Page, PageDetailsDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? $"{src.Author.FirstName} {src.Author.LastName}" : null))
            .ReverseMap();
        CreateMap<Page, CreatePageDto>().ReverseMap();
        CreateMap<Page, UpdatePageDto>().ReverseMap();

        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<Tag, TagDetailsDto>().ReverseMap();
        // Create/Update DTOs

        CreateMap<Media, MediaDto>().ReverseMap();
        CreateMap<Media, MediaDetailsDto>().ReverseMap();
        CreateMap<Media, CreateMediaDto>().ReverseMap();
        CreateMap<Media, UpdateMediaDto>().ReverseMap();
        CreateMap<BlogPostTag, BlogPostTagDto>().ReverseMap();
        CreateMap<BlogPostTag, BlogPostTagDetailsDto>().ReverseMap();
        // Create/Update DTOs

        // Customers
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerDetailsDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

        CreateMap<Address, AddressDto>().ReverseMap();

        // Inventory
        CreateMap<ProductInventory, ProductInventoryDto>().ReverseMap();
        CreateMap<ProductInventory, ProductInventoryDetailsDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
            .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse != null ? src.Warehouse.WarehouseName : string.Empty))
            .ReverseMap();
        CreateMap<ProductInventory, CreateProductInventoryDto>().ReverseMap();
        CreateMap<ProductInventory, UpdateProductInventoryDto>().ReverseMap();
        CreateMap<StockMovement, StockMovementDto>().ReverseMap();
        CreateMap<StockMovement, StockMovementDetailsDto>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductInventory != null && src.ProductInventory.Product != null ? src.ProductInventory.Product.ProductName : string.Empty))
            .ReverseMap();
        CreateMap<StockMovement, CreateStockMovementDto>().ReverseMap();
        CreateMap<StockMovement, StockMovementDetailsDto>()
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductInventory != null && src.ProductInventory.Product != null ? src.ProductInventory.Product.ProductName : string.Empty))
            .ReverseMap();
        CreateMap<StockMovement, UpdateStockMovementDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseDto>().ReverseMap();
        CreateMap<Warehouse, WarehouseDetailsDto>().ReverseMap();
        CreateMap<Warehouse, CreateWarehouseDto>().ReverseMap();
        CreateMap<Warehouse, UpdateWarehouseDto>().ReverseMap();

        // Logging
        CreateMap<LogEntry, LogEntryDto>().ReverseMap();

        // Marketing
        CreateMap<Campaign, CampaignDto>().ReverseMap();
        CreateMap<Campaign, CampaignDetailsDto>().ReverseMap();
        CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
        CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, EmailCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, EmailCampaignDetailsDto>().ReverseMap();
        CreateMap<EmailCampaign, CreateEmailCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, UpdateEmailCampaignDto>().ReverseMap();
        CreateMap<EmailTemplate, EmailTemplateDto>().ReverseMap();
        CreateMap<EmailTemplate, EmailTemplateDetailsDto>().ReverseMap();
        CreateMap<EmailTemplate, CreateEmailTemplateDto>().ReverseMap();
        CreateMap<EmailTemplate, UpdateEmailTemplateDto>().ReverseMap();
        CreateMap<Segment, SegmentDto>().ReverseMap();
        CreateMap<Segment, SegmentDetailsDto>().ReverseMap();
        CreateMap<Segment, CreateSegmentDto>().ReverseMap();
        CreateMap<Segment, UpdateSegmentDto>().ReverseMap();

        // Orders
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderDetailsDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? $"{src.Customer.FirstName} {src.Customer.LastName}" : null))
            .ReverseMap();
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemDetailsDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty))
            .ReverseMap();
        // Create/Update DTOs cho OrderItem (thao tác qua Order)
        CreateMap<OrderStatusHistory, OrderStatusHistoryDto>().ReverseMap();
        CreateMap<PaymentTransaction, PaymentTransactionDto>().ReverseMap();
        CreateMap<ShoppingCart, ShoppingCartDto>().ReverseMap();
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>().ReverseMap();

        // Products
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductDetailsDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand != null ? src.Brand.BrandName : null))
            .ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();

        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
        CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
        CreateMap<ProductAttribute, ProductAttributeDto>().ReverseMap();
        CreateMap<ProductAttributeValue, ProductAttributeValueDto>().ReverseMap();
        CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
        CreateMap<ProductReview, ProductReviewDetailsDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product != null ? src.Product.ProductName : null))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? $"{src.Customer.FirstName} {src.Customer.LastName}" : null))
            .ReverseMap();

        // Promotions
        CreateMap<Promotion, PromotionDto>().ReverseMap();
        CreateMap<Promotion, PromotionDetailsDto>().ReverseMap();
        CreateMap<Promotion, CreatePromotionDto>().ReverseMap();
        CreateMap<Promotion, UpdatePromotionDto>().ReverseMap();
        CreateMap<PromotionCategory, PromotionCategoryDto>().ReverseMap();
        CreateMap<PromotionProduct, PromotionProductDto>().ReverseMap();

        // Users
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserDetailsDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Role, RoleDetailsDto>().ReverseMap();
        CreateMap<Permission, PermissionDto>().ReverseMap();
        CreateMap<Permission, PermissionDetailsDto>().ReverseMap();
        CreateMap<UserRole, UserRoleDto>().ReverseMap();
        CreateMap<RolePermission, RolePermissionDto>().ReverseMap();
    }
}