using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;

public abstract record CreateSegmentCommand(CreateSegmentDto CreateSegmentDto) : IRequest<Result<Guid>>;