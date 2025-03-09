using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Media.DeleteMedia;

public record DeleteMediaCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}