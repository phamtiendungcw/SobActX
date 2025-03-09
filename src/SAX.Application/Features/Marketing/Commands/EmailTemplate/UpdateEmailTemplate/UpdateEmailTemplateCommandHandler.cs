using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public class UpdateEmailTemplateCommandHandler : IRequestHandler<UpdateEmailTemplateCommand, Result>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateEmailTemplateCommand> _validator;

    public UpdateEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository, IMapper mapper, IValidator<UpdateEmailTemplateCommand> validator)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateEmailTemplateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var emailTemplateDto = request.UpdateEmailTemplateDto;
        if (emailTemplateDto == null) return Result.Fail(new SaxBadRequestException("UpdateEmailTemplateDto is required.").Message);

        var emailTemplateToUpdate = await _emailTemplateRepository.GetByIdAsync(emailTemplateDto.Id, cancellationToken);
        if (emailTemplateToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.EmailTemplate), emailTemplateDto.Id).Message);

        _mapper.Map(request.UpdateEmailTemplateDto, emailTemplateToUpdate);
        await _emailTemplateRepository.UpdateAsync(emailTemplateToUpdate, cancellationToken);

        return Result.Ok();
    }
}