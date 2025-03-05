using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public class CreateMediaCommandHandler : IRequestHandler<CreateMediaCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IMediaRepository _mediaRepository;
    private readonly IValidator<CreateMediaCommand> _validator;

    public CreateMediaCommandHandler(IMediaRepository mediaRepository, IMapper mapper, IValidator<CreateMediaCommand> validator)
    {
        _mediaRepository = mediaRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var mediaToCreate = _mapper.Map<Domain.Entities.Content.Media>(request.CreateMediaDto);
        await _mediaRepository.CreateAsync(mediaToCreate, cancellationToken);

        return Result.Ok(mediaToCreate.Id);
    }
}