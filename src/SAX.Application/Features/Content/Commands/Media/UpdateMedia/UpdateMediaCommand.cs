using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public record UpdateMediaCommand : IRequest<Result>
{
    public UpdateMediaDto? UpdateMediaDto { get; set; }
}