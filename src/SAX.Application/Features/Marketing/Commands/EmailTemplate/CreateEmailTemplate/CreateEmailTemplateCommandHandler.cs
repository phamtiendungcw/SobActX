using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;

public class CreateEmailTemplateCommandHandler : IRequestHandler<CreateEmailTemplateCommand, Result<Guid>>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateEmailTemplateCommand> _validator;
    public CreateEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository, IMapper mapper, IValidator<CreateEmailTemplateCommand> validator)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Result<Guid>> Handle(CreateEmailTemplateCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createEmailTemplateDto = request.CreateEmailTemplateDto;
        if (createEmailTemplateDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu tạo mẫu email không hợp lệ: CreateEmailTemplateDto không được null.").Message);

        var emailTemplate = _mapper.Map<Domain.Entities.Marketing.EmailTemplate>(createEmailTemplateDto);
        await _emailTemplateRepository.AddAsync(emailTemplate, cancellationToken);

        return Result.Ok(emailTemplate.Id);
    }
}