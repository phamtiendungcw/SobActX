using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public sealed class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseCommandValidator()
    {
        RuleFor(x => x.CreateWarehouseDto)
            .NotNull().WithMessage("{PropertyName} is required.")
            .SetValidator(new CreateWarehouseDtoValidator());
    }
}