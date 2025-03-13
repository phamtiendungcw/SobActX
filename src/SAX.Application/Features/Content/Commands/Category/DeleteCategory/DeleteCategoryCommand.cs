using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Category.DeleteCategory;

public abstract record DeleteCategoryCommand(Guid Id) : IRequest<Result>;