using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public record UpdateTagCommand : IRequest<Result>
{
    public UpdateTagDto? UpdateTagDto { get; set; }
}