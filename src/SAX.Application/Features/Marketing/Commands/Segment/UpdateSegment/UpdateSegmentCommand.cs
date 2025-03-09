using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public record UpdateSegmentCommand : IRequest<Result>
{
    public UpdateSegmentDto? UpdateSegmentDto { get; set; }
}