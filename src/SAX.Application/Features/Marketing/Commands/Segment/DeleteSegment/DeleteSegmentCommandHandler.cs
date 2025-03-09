using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Segment.DeleteSegment;

public class DeleteSegmentCommandHandler : IRequestHandler<DeleteSegmentCommand, Result>
{
    private readonly ISegmentRepository _segmentRepository;

    public DeleteSegmentCommandHandler(ISegmentRepository segmentRepository)
    {
        _segmentRepository = segmentRepository;
    }

    public async Task<Result> Handle(DeleteSegmentCommand request, CancellationToken cancellationToken)
    {
        var segment = await _segmentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (segment == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.Segment), request.Id).Message);
        await _segmentRepository.DeleteAsync(segment, cancellationToken);
        return Result.Ok();
    }
}