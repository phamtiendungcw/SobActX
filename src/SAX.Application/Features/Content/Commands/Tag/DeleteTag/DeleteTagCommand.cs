using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Tag.DeleteTag;

public record DeleteTagCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}