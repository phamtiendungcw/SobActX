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
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId));
        CreateMap<Category, CategoryDetailsDto>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId));
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();

        CreateMap<Tag, TagDto>()
            .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId));
        CreateMap<Tag, TagDetailsDto>()
            .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId));
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();

        CreateMap<Page, PageDto>()
            .ForMember(dest => dest.PageId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PageId));
        CreateMap<Page, PageDetailsDto>()
            .ForMember(dest => dest.PageId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PageId));
        CreateMap<Page, CreatePageDto>().ReverseMap();
        CreateMap<Page, UpdatePageDto>().ReverseMap();

        CreateMap<BlogPost, BlogPostDto>()
            .ForMember(dest => dest.BlogPostId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BlogPostId));
        CreateMap<BlogPost, BlogPostDetailsDto>()
            .ForMember(dest => dest.BlogPostId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BlogPostId));
        CreateMap<BlogPost, CreateBlogPostDto>().ReverseMap();
        CreateMap<BlogPost, UpdateBlogPostDto>().ReverseMap();

        CreateMap<Media, MediaDto>()
            .ForMember(dest => dest.MediaId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MediaId));
        CreateMap<Media, MediaDetailsDto>()
            .ForMember(dest => dest.MediaId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MediaId));
        CreateMap<Media, CreateMediaDto>().ReverseMap();
        CreateMap<Media, UpdateMediaDto>().ReverseMap();

        // Customers Feature Mappings
        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
        CreateMap<Customer, CustomerDetailsDto>()
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

        CreateMap<Address, AddressDto>()
            .ForMember(dest => dest.AddressId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId));

        // Inventory Feature Mappings
        CreateMap<Warehouse, WarehouseDto>()
            .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WarehouseId));
        CreateMap<Warehouse, WarehouseDetailsDto>()
            .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.WarehouseId));
        CreateMap<Warehouse, CreateWarehouseDto>().ReverseMap();
        CreateMap<Warehouse, UpdateWarehouseDto>().ReverseMap();

        CreateMap<ProductInventory, ProductInventoryDto>()
            .ForMember(dest => dest.ProductInventoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductInventoryId));
        CreateMap<ProductInventory, ProductInventoryDetailsDto>()
            .ForMember(dest => dest.ProductInventoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductInventoryId));
        CreateMap<ProductInventory, CreateProductInventoryDto>().ReverseMap();
        CreateMap<ProductInventory, UpdateProductInventoryDto>().ReverseMap();

        CreateMap<StockMovement, StockMovementDto>()
            .ForMember(dest => dest.StockMovementId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StockMovementId));
        CreateMap<StockMovement, StockMovementDetailsDto>()
            .ForMember(dest => dest.StockMovementId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StockMovementId));

        // Logging Feature Mappings
        CreateMap<LogEntry, LogEntryDto>()
            .ForMember(dest => dest.LogEntryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LogEntryId));
        CreateMap<LogEntry, LogEntryDetailsDto>()
            .ForMember(dest => dest.LogEntryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LogEntryId));

        // Marketing Feature Mappings
        CreateMap<Campaign, CampaignDto>()
            .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CampaignId));
        CreateMap<Campaign, CampaignDetailsDto>()
            .ForMember(dest => dest.CampaignId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CampaignId));
        CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
        CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();

        CreateMap<EmailCampaign, EmailCampaignDto>()
            .ForMember(dest => dest.EmailCampaignId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmailCampaignId));
        CreateMap<EmailCampaign, EmailCampaignDetailsDto>()
            .ForMember(dest => dest.EmailCampaignId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmailCampaignId));
        CreateMap<EmailCampaign, CreateEmailCampaignDto>().ReverseMap();
        CreateMap<EmailCampaign, UpdateEmailCampaignDto>().ReverseMap();

        CreateMap<Segment, SegmentDto>()
            .ForMember(dest => dest.SegmentId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SegmentId));
        CreateMap<Segment, SegmentDetailsDto>()
            .ForMember(dest => dest.SegmentId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SegmentId));
        CreateMap<Segment, CreateSegmentDto>().ReverseMap();
        CreateMap<Segment, UpdateSegmentDto>().ReverseMap();

        CreateMap<EmailTemplate, EmailTemplateDto>()
            .ForMember(dest => dest.EmailTemplateId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmailTemplateId));
        CreateMap<EmailTemplate, EmailTemplateDetailsDto>()
            .ForMember(dest => dest.EmailTemplateId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmailTemplateId));
        CreateMap<EmailTemplate, CreateEmailTemplateDto>().ReverseMap();
        CreateMap<EmailTemplate, UpdateEmailTemplateDto>().ReverseMap();

        // Orders Feature Mappings
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));
        CreateMap<Order, OrderDetailsDto>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.OrderItemId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderItemId));
        CreateMap<OrderItem, OrderItemCreateDto>().ReverseMap()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<OrderStatusHistory, OrderStatusHistoryDto>()
            .ForMember(dest => dest.OrderStatusHistoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderStatusHistoryId));
        CreateMap<PaymentTransaction, PaymentTransactionDto>()
            .ForMember(dest => dest.PaymentTransactionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PaymentTransactionId));

        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.ShoppingCartId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ShoppingCartId));
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
            .ForMember(dest => dest.ShoppingCartItemId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ShoppingCartItemId));

        // Products Feature Mappings
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
        CreateMap<Product, ProductDetailsDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();

        CreateMap<ProductCategory, ProductCategoryDto>()
            .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductCategoryId));
        CreateMap<ProductBrand, ProductBrandDto>()
            .ForMember(dest => dest.ProductBrandId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductBrandId));
        CreateMap<ProductAttribute, ProductAttributeDto>()
            .ForMember(dest => dest.ProductAttributeId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductAttributeId));
        CreateMap<ProductAttributeValue, ProductAttributeValueDto>()
            .ForMember(dest => dest.ProductAttributeValueId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductAttributeValueId));
        CreateMap<ProductReview, ProductReviewDto>()
            .ForMember(dest => dest.ProductReviewId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductReviewId));

        // Promotions Feature Mappings
        CreateMap<Promotion, PromotionDto>()
            .ForMember(dest => dest.PromotionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionId));
        CreateMap<Promotion, PromotionDetailsDto>()
            .ForMember(dest => dest.PromotionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionId));
        CreateMap<Promotion, CreatePromotionDto>().ReverseMap();
        CreateMap<Promotion, UpdatePromotionDto>().ReverseMap();

        CreateMap<PromotionProduct, PromotionProductDto>()
            .ForMember(dest => dest.PromotionProductId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionProductId));
        CreateMap<PromotionProduct, PromotionProductDetailsDto>()
            .ForMember(dest => dest.PromotionProductId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionProductId));
        CreateMap<PromotionProduct, CreatePromotionProductDto>().ReverseMap();
        CreateMap<PromotionProduct, UpdatePromotionProductDto>().ReverseMap();

        CreateMap<PromotionCategory, PromotionCategoryDto>()
            .ForMember(dest => dest.PromotionCategoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionCategoryId));
        CreateMap<PromotionCategory, PromotionCategoryDetailsDto>()
            .ForMember(dest => dest.PromotionCategoryId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PromotionCategoryId));
        CreateMap<PromotionCategory, CreatePromotionCategoryDto>().ReverseMap();
        CreateMap<PromotionCategory, UpdatePromotionCategoryDto>().ReverseMap();

        // Users Feature Mappings
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        CreateMap<User, UserDetailsDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();

        CreateMap<Role, RoleDto>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
        CreateMap<Role, RoleDetailsDto>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
        CreateMap<Role, CreateRoleDto>().ReverseMap();
        CreateMap<Role, UpdateRoleDto>().ReverseMap();

        CreateMap<Permission, PermissionDto>()
            .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PermissionId));
        CreateMap<Permission, PermissionDetailsDto>()
            .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PermissionId));
        CreateMap<Permission, CreatePermissionDto>().ReverseMap();
        CreateMap<Permission, UpdatePermissionDto>().ReverseMap();

        CreateMap<UserRole, UserRoleDto>()
            .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserRoleId));
        CreateMap<UserRole, UserRoleDetailsDto>()
            .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserRoleId));
        CreateMap<UserRole, CreateUserRoleDto>().ReverseMap();
        CreateMap<UserRole, UpdateUserRoleDto>().ReverseMap();

        CreateMap<RolePermission, RolePermissionDto>()
            .ForMember(dest => dest.RolePermissionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RolePermissionId));
        CreateMap<RolePermission, RolePermissionDetailsDto>()
            .ForMember(dest => dest.RolePermissionId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RolePermissionId));
        CreateMap<RolePermission, CreateRolePermissionDto>().ReverseMap();
        CreateMap<RolePermission, UpdateRolePermissionDto>().ReverseMap();
    }
}