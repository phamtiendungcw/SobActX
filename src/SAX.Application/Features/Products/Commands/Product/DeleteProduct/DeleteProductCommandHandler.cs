using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Products;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Products.Commands.Product.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productToDelete = await _unitOfWork.Repository<Domain.Entities.Products.Product>().GetByIdAsync(request.Id, cancellationToken);
        if (productToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Product), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Products.Product>().DeleteAsync(productToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}