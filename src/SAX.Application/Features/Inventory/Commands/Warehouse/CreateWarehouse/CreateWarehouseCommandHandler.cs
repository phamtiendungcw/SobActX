using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.CreateWarehouse;

public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateWarehouseCommand> _validator;
    private readonly IWarehouseRepository _warehouseRepository;

    public CreateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, IValidator<CreateWarehouseCommand> validator)
    {
        _mapper = mapper;
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
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

        var warehouseDto = request.CreateWarehouseDto;
        var warehouse = _mapper.Map<Domain.Entities.Inventory.Warehouse>(warehouseDto);

        await _unitOfWork.Repository<Domain.Entities.Inventory.Warehouse>().AddAsync(warehouse, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(warehouse.Id);
    }
}