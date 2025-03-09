using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Products.Commands.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IValidator<CreateProductCommand> validator)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createProductDto = request.CreateProductDto;
        if (createProductDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu tạo sản phẩm không hợp lệ: CreateProductDto không được null.").Message);

        var productToCreate = _mapper.Map<Domain.Entities.Products.Product>(createProductDto);
        var createdProduct = await _productRepository.CreateAsync(productToCreate, cancellationToken);

        return Result.Ok(createdProduct.Id);
    }
}