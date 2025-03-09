using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;
    private readonly IValidator<UpdateTagCommand> _validator;

    public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository, IValidator<UpdateTagCommand> validator)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
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
        if (updateTagDto == null) return Result.Fail("UpdateTagDto cannot be null.");

        var tagToUpdate = await _tagRepository.GetByIdAsync(updateTagDto.Id, cancellationToken);
        if (tagToUpdate == null) return Result.Fail($"Không tìm thấy thẻ với ID: {updateTagDto.Id}");

        _mapper.Map(request.UpdateTagDto, tagToUpdate);
        await _tagRepository.UpdateAsync(tagToUpdate, cancellationToken);

        return Result.Ok();
    }
}