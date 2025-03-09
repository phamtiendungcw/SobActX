using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Segment.CreateSegment;

public class CreateSegmentCommandHandler : IRequestHandler<CreateSegmentCommand, Result<Guid>>
{
    private readonly ISegmentRepository _segmentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateSegmentCommand> _validator;

    public CreateSegmentCommandHandler(ISegmentRepository segmentRepository, IMapper mapper, IValidator<CreateSegmentCommand> validator)
    {
        _segmentRepository = segmentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateSegmentCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createSegmentDto = request.CreateSegmentDto;
        if (createSegmentDto == null) return Result.Fail(new SaxBadRequestException("CreateSegmentDto is required.").Message);

        var segment = _mapper.Map<Domain.Entities.Marketing.Segment>(createSegmentDto);
        await _segmentRepository.AddAsync(segment, cancellationToken);

        return Result.Ok(segment.Id);
    }
}