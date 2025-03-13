using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, Result<Guid>>
{
    private readonly IMediaRepository _mediaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateMediaCommand> _validator;

    public CreateMediaCommandHandler(IMediaRepository mediaRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateMediaCommand> validator)
    {
        _mediaRepository = mediaRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createMediaDto = request.CreateMediaDto;
        var media = _mapper.Map<Domain.Entities.Content.Media>(createMediaDto);

        await _unitOfWork.Repository<Domain.Entities.Content.Media>().AddAsync(media, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(media.Id);
    }
}