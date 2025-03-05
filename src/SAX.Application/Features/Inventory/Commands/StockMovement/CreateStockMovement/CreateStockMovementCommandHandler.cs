using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.StockMovement.CreateStockMovement;

public class CreateStockMovementCommandHandler : IRequestHandler<CreateStockMovementCommand, Result<Guid>>
{
    private readonly IStockMovementRepository _stockMovementRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateStockMovementCommand> _validator;

    public CreateStockMovementCommandHandler(IStockMovementRepository stockMovementRepository, IMapper mapper, IValidator<CreateStockMovementCommand> validator)
    {
        _stockMovementRepository = stockMovementRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateStockMovementCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var stockMovementDto = request.StockMovementDto;
        var stockMovementToCreate = _mapper.Map<Domain.Entities.Inventory.StockMovement>(stockMovementDto);
        var createdStockMovement = await _stockMovementRepository.CreateAsync(stockMovementToCreate, cancellationToken);

        return Result.Ok(createdStockMovement.Id);
    }
}