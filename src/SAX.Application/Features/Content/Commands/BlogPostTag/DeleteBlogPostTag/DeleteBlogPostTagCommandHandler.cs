using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.DeleteBlogPostTag;

public class DeleteBlogPostTagCommandHandler : IRequestHandler<DeleteBlogPostTagCommand, Result>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBlogPostTagCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBlogPostTagCommand request, CancellationToken cancellationToken)
    {
        var blogPostTagToDelete = await _unitOfWork.Repository<Domain.Entities.Content.BlogPostTag>().GetByIdAsync(request.Id, cancellationToken);
        if (blogPostTagToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(BlogPostTag), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Content.BlogPostTag>().DeleteAsync(blogPostTagToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}