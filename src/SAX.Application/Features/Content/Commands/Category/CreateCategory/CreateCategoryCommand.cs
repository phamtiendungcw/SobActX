using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Category;

namespace SAX.Application.Features.Content.Commands.Category.CreateCategory;

public record CreateCategoryCommand : IRequest<Result<Guid>>
{
    public CreateCategoryDto? CreateCategoryDto { get; set; }
}