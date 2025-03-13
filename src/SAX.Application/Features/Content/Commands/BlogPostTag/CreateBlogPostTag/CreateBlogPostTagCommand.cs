using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPostTag;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.CreateBlogPostTag;

public abstract record CreateBlogPostTagCommand(CreateBlogPostTagDto CreateBlogPostTagDto) : IRequest<Result<Guid>>;