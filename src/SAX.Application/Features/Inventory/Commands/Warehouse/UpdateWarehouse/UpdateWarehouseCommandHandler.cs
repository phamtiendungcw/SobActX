using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IValidator<UpdateWarehouseCommand> _validator;

    public UpdateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository, IValidator<UpdateWarehouseCommand> validator)
    {
        _mapper = mapper;
        _warehouseRepository = warehouseRepository;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var warehouseDto = request.UpdateWarehouseDto;
        if (warehouseDto == null)
        {
            return Result.Fail("Warehouse data is missing.");
        }
        var warehouseToUpdate = await _warehouseRepository.GetByIdAsync(warehouseDto.WarehouseId, cancellationToken);
        if (warehouseToUpdate == null)
        {
            return Result.Fail($"Warehouse with ID {warehouseDto.WarehouseId} not found.");
        }

        _mapper.Map(warehouseDto, warehouseToUpdate);
        await _warehouseRepository.UpdateAsync(warehouseToUpdate, cancellationToken);

        return Result.Ok();
    }
}