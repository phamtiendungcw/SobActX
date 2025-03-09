using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public class CreateEmailCampaignCommandHandler : IRequestHandler<CreateEmailCampaignCommand, Result<Guid>>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateEmailCampaignCommand> _validator;

    public CreateEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository, IMapper mapper, IValidator<CreateEmailCampaignCommand> validator)
    {
        _emailCampaignRepository = emailCampaignRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateEmailCampaignCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }
        var createEmailCampaignDto = request.CreateEmailCampaignDto;
        var emailCampaignToCreate = _mapper.Map<Domain.Entities.Marketing.EmailCampaign>(createEmailCampaignDto);
        var createdEmailCampaign = await _emailCampaignRepository.CreateAsync(emailCampaignToCreate, cancellationToken);

        return Result.Ok(createdEmailCampaign.Id);
    }
}