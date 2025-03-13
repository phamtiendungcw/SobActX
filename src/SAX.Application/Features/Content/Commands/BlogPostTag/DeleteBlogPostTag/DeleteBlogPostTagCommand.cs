using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.DeleteBlogPostTag;

public abstract record DeleteBlogPostTagCommand(Guid Id) : IRequest<Result>;