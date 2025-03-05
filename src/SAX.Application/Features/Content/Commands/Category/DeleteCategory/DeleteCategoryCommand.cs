using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Category.DeleteCategory;

public record DeleteCategoryCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}