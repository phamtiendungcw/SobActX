using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public class CreateProductInventoryCommandHandler : IRequestHandler<CreateProductInventoryCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IProductInventoryRepository _productInventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateProductInventoryCommand> _validator;

    public CreateProductInventoryCommandHandler(IProductInventoryRepository productInventoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductInventoryCommand> validator)
    {
        _productInventoryRepository = productInventoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateProductInventoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var productInventoryDto = request.CreateProductInventoryDto;
        var productInventory = _mapper.Map<Domain.Entities.Inventory.ProductInventory>(productInventoryDto);

        await _unitOfWork.Repository<Domain.Entities.Inventory.ProductInventory>().AddAsync(productInventory, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(productInventory.Id);
    }
}