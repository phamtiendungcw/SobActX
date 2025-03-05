using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;

public class UpdateWarehouseCommandValidator : AbstractValidator<UpdateWarehouseCommand>
{
    public UpdateWarehouseCommandValidator()
    {
        RuleFor(p => p.UpdateWarehouseDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new UpdateWarehouseDtoValidator());
    }
}