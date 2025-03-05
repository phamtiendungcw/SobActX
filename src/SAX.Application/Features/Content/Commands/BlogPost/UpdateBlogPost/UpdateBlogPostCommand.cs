using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;

public record UpdateBlogPostCommand() : IRequest<Result>
{
    public UpdateBlogPostDto? UpdateBlogPostDto { get; set; }
}