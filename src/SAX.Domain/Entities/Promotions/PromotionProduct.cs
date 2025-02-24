﻿using SAX.Domain.Entities.Products;

namespace SAX.Domain.Entities.Promotions;

public class PromotionProduct : BaseEntity
{
    public int PromotionId { get; set; } // Foreign key to Promotion
    public Promotion? Promotion { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key to Product
    public Product? Product { get; set; } // Navigation property
}