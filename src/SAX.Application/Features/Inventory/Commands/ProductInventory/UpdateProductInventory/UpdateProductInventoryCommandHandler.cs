using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public class UpdateProductInventoryCommandHandler : IRequestHandler<UpdateProductInventoryCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IProductInventoryRepository _productInventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateProductInventoryCommand> _validator;

    public UpdateProductInventoryCommandHandler(IMapper mapper, IProductInventoryRepository productInventoryRepository, IUnitOfWork unitOfWork,
        IValidator<UpdateProductInventoryCommand> validator)
    {
        _mapper = mapper;
        _productInventoryRepository = productInventoryRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateProductInventoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var productInventoryDto = request.UpdateProductInventoryDto;
        var productInventoryToUpdate = await _unitOfWork.Repository<Domain.Entities.Inventory.ProductInventory>().GetByIdAsync(productInventoryDto.Id, cancellationToken);
        if (productInventoryToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.ProductInventory), productInventoryDto.Id).Message);
        _mapper.Map(productInventoryDto, productInventoryToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Inventory.ProductInventory>().UpdateAsync(productInventoryToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}