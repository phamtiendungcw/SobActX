using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Category.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

        if (categoryToDelete == null)
        {
            return Result.Fail(new SobActXNotFoundException($"Category with Id {request.Id} not found.").Message);
        }

        await _categoryRepository.DeleteAsync(categoryToDelete, cancellationToken);

        return Result.Ok();
    }
}