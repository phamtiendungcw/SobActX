using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Result<Guid>>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCampaignCommand> _validator;

    public CreateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper, IValidator<CreateCampaignCommand> validator)
    {
        _campaignRepository = campaignRepository;
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

        var createCampaignDto = request.CreateCampaignDto;
        var campaignToCreate = _mapper.Map<Domain.Entities.Marketing.Campaign>(createCampaignDto);
        var createdCampaign = await _campaignRepository.CreateAsync(campaignToCreate, cancellationToken);

        return Result.Ok(createdCampaign.Id);
    }
}