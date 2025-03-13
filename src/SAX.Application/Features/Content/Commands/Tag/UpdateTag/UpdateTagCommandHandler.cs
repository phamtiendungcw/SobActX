using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateTagCommand> _validator;

    public UpdateTagCommandHandler(ITagRepository tagRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateTagCommand> validator)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateTagDto = request.UpdateTagDto;
        var tagToUpdate = await _unitOfWork.Repository<Domain.Entities.Content.Tag>().GetByIdAsync(updateTagDto.Id, cancellationToken);
        if (tagToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Tag), updateTagDto.Id).Message);
        _mapper.Map(updateTagDto, tagToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Content.Tag>().UpdateAsync(tagToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}