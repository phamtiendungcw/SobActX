using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IMediaRepository _mediaRepository;
    private readonly IValidator<UpdateMediaCommand> _validator;

    public UpdateMediaCommandHandler(IMediaRepository mediaRepository, IMapper mapper, IValidator<UpdateMediaCommand> validator)
    {
        _mediaRepository = mediaRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateMediaDto = request.UpdateMediaDto;
        if (updateMediaDto == null) return Result.Fail("UpdateMediaDto cannot be null.");
        var mediaToUpdate = await _mediaRepository.GetByIdAsync(updateMediaDto.MediaId, cancellationToken);
        if (mediaToUpdate == null) return Result.Fail($"Không tìm thấy phương tiện truyền thông với ID: {updateMediaDto.MediaId}");
        _mapper.Map(request.UpdateMediaDto, mediaToUpdate);
        await _mediaRepository.UpdateAsync(mediaToUpdate, cancellationToken);

        return Result.Ok();
    }
}