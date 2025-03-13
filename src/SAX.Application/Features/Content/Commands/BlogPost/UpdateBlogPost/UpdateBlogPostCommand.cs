using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;

public abstract record UpdateBlogPostCommand(UpdateBlogPostDto UpdateBlogPostDto) : IRequest<Result>;