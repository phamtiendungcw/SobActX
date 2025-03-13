using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Segment.DeleteSegment;

public class DeleteSegmentCommandHandler : IRequestHandler<DeleteSegmentCommand, Result>
{
    private readonly ISegmentRepository _segmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSegmentCommandHandler(ISegmentRepository segmentRepository, IUnitOfWork unitOfWork)
    {
        _segmentRepository = segmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSegmentCommand request, CancellationToken cancellationToken)
    {
        var segmentToDelete = await _unitOfWork.Repository<Domain.Entities.Marketing.Segment>().GetByIdAsync(request.Id, cancellationToken);
        if (segmentToDelete is null) return Result.Fail(new SaxNotFoundException(nameof(Segment), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Marketing.Segment>().DeleteAsync(segmentToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}