using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Segment.UpdateSegment;

public class UpdateSegmentCommandHandler : IRequestHandler<UpdateSegmentCommand, Result>
{
    private readonly ISegmentRepository _segmentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateSegmentCommand> _validator;

    public UpdateSegmentCommandHandler(ISegmentRepository segmentRepository, IMapper mapper, IValidator<UpdateSegmentCommand> validator)
    {
        _segmentRepository = segmentRepository;
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

        var updateSegmentDto = request.UpdateSegmentDto;
        if (updateSegmentDto == null) return Result.Fail(new SaxBadRequestException("UpdateSegmentDto is required.").Message);

        var segmentToUpdate = await _segmentRepository.GetByIdAsync(updateSegmentDto.Id, cancellationToken);
        if (segmentToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.Segment), updateSegmentDto.Id).Message);

        _mapper.Map(request.UpdateSegmentDto, segmentToUpdate);
        await _segmentRepository.UpdateAsync(segmentToUpdate, cancellationToken);

        return Result.Ok();
    }
}