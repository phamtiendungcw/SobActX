using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.BlogPost.DeleteBlogPost;

public abstract record DeleteBlogPostCommand(Guid Id) : IRequest<Result>;