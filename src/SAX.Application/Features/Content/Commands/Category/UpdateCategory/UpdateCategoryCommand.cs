using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public abstract record UpdateCategoryCommand(UpdateCategoryDto UpdateCategoryDto) : IRequest<Result>;