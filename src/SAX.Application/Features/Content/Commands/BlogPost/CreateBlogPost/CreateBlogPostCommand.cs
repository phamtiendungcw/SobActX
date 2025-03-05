using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public record CreateBlogPostCommand : IRequest<Result<Guid>>
{
    public CreateBlogPostDto? CreateBlogPostDto { get; set; }
}