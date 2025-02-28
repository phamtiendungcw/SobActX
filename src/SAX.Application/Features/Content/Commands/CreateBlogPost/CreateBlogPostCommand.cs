using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.BlogPost;

namespace SAX.Application.Features.Content.Commands.CreateBlogPost;

public record CreateBlogPostCommand(CreateBlogPostDto CreateBlogPostDto) : IRequest<Result<Guid>>;