using FluentValidation;

using SAX.Application.Features.Inventory.Validators;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseCommandValidator()
    {
        RuleFor(x => x.CreateWarehouseDto).NotNull().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.CreateWarehouseDto!).SetValidator(new CreateWarehouseDtoValidator());
    }
}