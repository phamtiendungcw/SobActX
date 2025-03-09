using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.CreateProductInventory;

public class CreateProductInventoryCommandHandler : IRequestHandler<CreateProductInventoryCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IProductInventoryRepository _productInventoryRepository;
    private readonly IValidator<CreateProductInventoryCommand> _validator;

    public CreateProductInventoryCommandHandler(IProductInventoryRepository productInventoryRepository, IMapper mapper, IValidator<CreateProductInventoryCommand> validator)
    {
        _productInventoryRepository = productInventoryRepository;
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

        var createProductInventoryDto = request.CreateProductInventoryDto;
        var productInventoryToCreate = _mapper.Map<Domain.Entities.Inventory.ProductInventory>(createProductInventoryDto);
        var createdProductInventory = await _productInventoryRepository.CreateAsync(productInventoryToCreate, cancellationToken);

        return Result.Ok(createdProductInventory.Id);
    }
}