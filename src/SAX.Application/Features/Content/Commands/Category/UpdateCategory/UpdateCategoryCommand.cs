using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public record UpdateCategoryCommand : IRequest<Result>
{
    public UpdateCategoryDto? UpdateCategoryDto { get; set; }
}