using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Tag.CreateTag;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _tagRepository;
    private readonly IValidator<CreateTagCommand> _validator;

    public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper, IValidator<CreateTagCommand> validator)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var tagToCreate = _mapper.Map<Domain.Entities.Content.Tag>(request.CreateTagDto);
        await _tagRepository.CreateAsync(tagToCreate, cancellationToken);

        return Result.Ok(tagToCreate.Id);
    }
}