using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPost.DeleteBlogPost;

public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, Result>
{
    private readonly IBlogPostRepository _blogPostRepository;

    public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
    }

    public async Task<Result> Handle(DeleteBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPostToDelete = await _blogPostRepository.GetByIdAsync(request.Id, cancellationToken);
        if (blogPostToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.BlogPost), request.Id).Message);

        await _blogPostRepository.DeleteAsync(blogPostToDelete, cancellationToken);

        return Result.Ok();
    }
}