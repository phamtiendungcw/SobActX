using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public abstract record CreateBlogPostCommand(CreateBlogPostDto CreateBlogPostDto) : IRequest<Result<Guid>>;
