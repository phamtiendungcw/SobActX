using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.Segment.DeleteSegment;

public abstract record DeleteSegmentCommand(Guid Id) : IRequest<Result>;