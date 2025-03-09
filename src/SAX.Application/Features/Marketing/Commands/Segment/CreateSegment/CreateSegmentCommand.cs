using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;

public record CreateSegmentCommand : IRequest<Result<Guid>>
{
    public CreateSegmentDto? CreateSegmentDto { get; set; }
}