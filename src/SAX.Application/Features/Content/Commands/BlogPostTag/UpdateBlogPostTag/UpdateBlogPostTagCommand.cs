using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPostTag;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.UpdateBlogPostTag;

public abstract record UpdateBlogPostTagCommand(UpdateBlogPostTagDto UpdateBlogPostTagDto) : IRequest<Result>;