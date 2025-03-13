using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.Warehouse.UpdateWarehouse;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateWarehouseCommand> _validator;
    private readonly IWarehouseRepository _warehouseRepository;

    public UpdateWarehouseCommandHandler(IMapper mapper, IWarehouseRepository warehouseRepository, IUnitOfWork unitOfWork, IValidator<UpdateWarehouseCommand> validator)
    {
        _mapper = mapper;
        _warehouseRepository = warehouseRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var warehouseDto = request.UpdateWarehouseDto;
        var warehouseToUpdate = await _unitOfWork.Repository<Domain.Entities.Inventory.Warehouse>().GetByIdAsync(warehouseDto.Id, cancellationToken);
        if (warehouseToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.Warehouse), warehouseDto.Id).Message);
        _mapper.Map(warehouseDto, warehouseToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Inventory.Warehouse>().UpdateAsync(warehouseToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}