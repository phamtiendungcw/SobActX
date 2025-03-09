using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Inventory;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Inventory.Commands.ProductInventory.UpdateProductInventory;

public class UpdateProductInventoryCommandHandler : IRequestHandler<UpdateProductInventoryCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IProductInventoryRepository _productInventoryRepository;
    private readonly IValidator<UpdateProductInventoryCommand> _validator;

    public UpdateProductInventoryCommandHandler(IMapper mapper, IProductInventoryRepository productInventoryRepository, IValidator<UpdateProductInventoryCommand> validator)
    {
        _mapper = mapper;
        _productInventoryRepository = productInventoryRepository;
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
        if (productInventoryDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật sản phẩm tồn kho không hợp lệ: UpdateProductInventoryDto không được null.").Message);
        var productInventoryToUpdate = await _productInventoryRepository.GetByIdAsync(productInventoryDto.Id, cancellationToken);
        if (productInventoryToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Inventory.ProductInventory), productInventoryDto.Id).Message);

        _mapper.Map(productInventoryDto, productInventoryToUpdate);
        await _productInventoryRepository.UpdateAsync(productInventoryToUpdate, cancellationToken);

        return Result.Ok();
    }
}