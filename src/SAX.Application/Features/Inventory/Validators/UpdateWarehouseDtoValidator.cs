using FluentValidation;

using SAX.Application.Features.Inventory.DTOs.Warehouse;

namespace SAX.Application.Features.Inventory.Validators;

public class UpdateWarehouseDtoValidator : AbstractValidator<UpdateWarehouseDto>
{
    public UpdateWarehouseDtoValidator()
    {
        RuleFor(p => p.WarehouseId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.WarehouseName)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.WarehouseName));

        RuleFor(p => p.StreetAddress)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.")
            .When(p => !string.IsNullOrEmpty(p.StreetAddress));

        RuleFor(p => p.City)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.City));

        RuleFor(p => p.State)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .When(p => !string.IsNullOrEmpty(p.State));

        RuleFor(p => p.ZipCode)
            .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.")
            .When(p => !string.IsNullOrEmpty(p.ZipCode));

        RuleFor(p => p.Country)
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}