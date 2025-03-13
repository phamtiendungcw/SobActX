using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;

public class CreateEmailTemplateCommandHandler : IRequestHandler<CreateEmailTemplateCommand, Result<Guid>>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateEmailTemplateCommand> _validator;

    public CreateEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<CreateEmailTemplateCommand> validator)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _unitOfWork = unitOfWork;
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

        var emailTemplateDto = request.CreateEmailTemplateDto;
        var emailTemplate = _mapper.Map<Domain.Entities.Marketing.EmailTemplate>(emailTemplateDto);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailTemplate>().AddAsync(emailTemplate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(emailTemplate.Id);
    }
}