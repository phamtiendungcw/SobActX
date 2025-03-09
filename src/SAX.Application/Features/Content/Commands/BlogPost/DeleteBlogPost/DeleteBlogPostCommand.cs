using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.BlogPost.DeleteBlogPost;

public record DeleteBlogPostCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}