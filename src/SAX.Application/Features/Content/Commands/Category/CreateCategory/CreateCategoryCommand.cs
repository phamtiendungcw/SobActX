using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Commands.Category.CreateCategory;

public abstract record CreateCategoryCommand(CreateCategoryDto CreateCategoryDto) : IRequest<Result<Guid>>;