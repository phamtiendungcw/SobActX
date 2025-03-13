using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public abstract record UpdateSegmentCommand(UpdateSegmentDto UpdateSegmentDto) : IRequest<Result>;