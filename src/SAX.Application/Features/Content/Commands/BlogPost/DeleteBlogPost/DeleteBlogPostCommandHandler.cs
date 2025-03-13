using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPost.DeleteBlogPost;

public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, Result>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPostToDelete = await _unitOfWork.Repository<Domain.Entities.Content.BlogPost>().GetByIdAsync(request.Id, cancellationToken);
        if (blogPostToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.BlogPost), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Content.BlogPost>().DeleteAsync(blogPostToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}