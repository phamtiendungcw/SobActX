using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Products.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateProductCommand> _validator;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IValidator<UpdateProductCommand> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateProductDto = request.UpdateProductDto;
        if (updateProductDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật sản phẩm không hợp lệ: UpdateProductDto không được null.").Message);

        var productToUpdate = await _productRepository.GetByIdAsync(updateProductDto.Id, cancellationToken);
        if (productToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Products.Product), updateProductDto.Id).Message);

        _mapper.Map(updateProductDto, productToUpdate);
        await _productRepository.UpdateAsync(productToUpdate, cancellationToken);

        return Result.Ok();
    }
}