using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public record CreateMediaCommand : IRequest<Result<Guid>>
{
    public CreateMediaDto? CreateMediaDto { get; set; }
}