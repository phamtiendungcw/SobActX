using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public class CreateEmailCampaignCommandHandler : IRequestHandler<CreateEmailCampaignCommand, Result<Guid>>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateEmailCampaignCommand> _validator;

    public CreateEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<CreateEmailCampaignCommand> validator)
    {
        _emailCampaignRepository = emailCampaignRepository;
        _unitOfWork = unitOfWork;
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

        var emailCampaignDto = request.CreateEmailCampaignDto;
        var emailCampaign = _mapper.Map<Domain.Entities.Marketing.EmailCampaign>(emailCampaignDto);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailCampaign>().AddAsync(emailCampaign, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(emailCampaign.Id);
    }
}