using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public class UpdateEmailTemplateCommandHandler : IRequestHandler<UpdateEmailTemplateCommand, Result>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateEmailTemplateCommand> _validator;

    public UpdateEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<UpdateEmailTemplateCommand> validator)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _unitOfWork = unitOfWork;
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
        var emailTemplate = await _unitOfWork.Repository<Domain.Entities.Marketing.EmailTemplate>().GetByIdAsync(emailTemplateDto.Id, cancellationToken);
        if (emailTemplate is null) return Result.Fail(new SaxNotFoundException(nameof(EmailTemplate), emailTemplateDto.Id).Message);
        _mapper.Map(emailTemplateDto, emailTemplate);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailTemplate>().UpdateAsync(emailTemplate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}