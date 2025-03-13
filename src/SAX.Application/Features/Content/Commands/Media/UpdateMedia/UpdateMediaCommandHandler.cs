using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public class UpdateMediaCommandHandler : IRequestHandler<UpdateMediaCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IMediaRepository _mediaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateMediaCommand> _validator;

    public UpdateMediaCommandHandler(IMediaRepository mediaRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateMediaCommand> validator)
    {
        _mediaRepository = mediaRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateMediaDto = request.UpdateMediaDto;
        var mediaToUpdate = await _unitOfWork.Repository<Domain.Entities.Content.Media>().GetByIdAsync(updateMediaDto.Id, cancellationToken);
        if (mediaToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Media), updateMediaDto.Id).Message);
        _mapper.Map(updateMediaDto, mediaToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Content.Media>().UpdateAsync(mediaToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}