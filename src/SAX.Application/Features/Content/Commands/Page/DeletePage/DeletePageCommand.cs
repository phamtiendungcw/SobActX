using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Page.DeletePage;

public record DeletePageCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}