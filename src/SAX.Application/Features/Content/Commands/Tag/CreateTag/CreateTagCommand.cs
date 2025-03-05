using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Commands.Tag.CreateTag;

public record CreateTagCommand : IRequest<Result<Guid>>
{
    public CreateTagDto? CreateTagDto { get; set; }
}