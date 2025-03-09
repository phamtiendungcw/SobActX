using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.Segment.DeleteSegment;

public record DeleteSegmentCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}