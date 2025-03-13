using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Result<Guid>>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCampaignCommand> _validator;

    public CreateCampaignCommandHandler(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCampaignCommand> validator)
    {
        _campaignRepository = campaignRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var campaignDto = request.CreateCampaignDto;
        var campaign = _mapper.Map<Domain.Entities.Marketing.Campaign>(campaignDto);

        await _unitOfWork.Repository<Domain.Entities.Marketing.Campaign>().AddAsync(campaign, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(campaign.Id);
    }
}