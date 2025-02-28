using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Commands.CreateCategory;

public record CreateCategoryCommand(CreateCategoryDto CreateCategoryDto) : IRequest<Result<Guid>>;