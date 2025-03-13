using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public class UpdateSegmentCommandHandler : IRequestHandler<UpdateSegmentCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly ISegmentRepository _segmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateSegmentCommand> _validator;

    public UpdateSegmentCommandHandler(ISegmentRepository segmentRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateSegmentCommand> validator)
    {
        _segmentRepository = segmentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateSegmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var segmentDto = request.UpdateSegmentDto;
        var segment = await _unitOfWork.Repository<Domain.Entities.Marketing.Segment>().GetByIdAsync(segmentDto.Id, cancellationToken);
        if (segment is null) return Result.Fail(new SaxNotFoundException(nameof(Segment), segmentDto.Id).Message);
        _mapper.Map(segmentDto, segment);

        await _unitOfWork.Repository<Domain.Entities.Marketing.Segment>().UpdateAsync(segment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}