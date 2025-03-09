using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IValidator<CreateWarehouseCommand> _validator;

    public CreateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository, IValidator<CreateWarehouseCommand> validator)
    {
        _mapper = mapper;
        _warehouseRepository = warehouseRepository;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createWarehouseDto = request.CreateWarehouseDto;
        var warehouseToCreate = _mapper.Map<Domain.Entities.Inventory.Warehouse>(createWarehouseDto);
        var createdWarehouse = await _warehouseRepository.AddAsync(warehouseToCreate, cancellationToken);

        return Result.Ok(createdWarehouse.Id);
    }
}