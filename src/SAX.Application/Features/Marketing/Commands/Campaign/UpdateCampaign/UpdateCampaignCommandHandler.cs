using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Result>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateCampaignCommand> _validator;

    public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCampaignCommand> validator)
    {
        _campaignRepository = campaignRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var campaignDto = request.UpdateCampaignDto;
        var campaignToUpdate = await _unitOfWork.Repository<Domain.Entities.Marketing.Campaign>().GetByIdAsync(campaignDto.Id, cancellationToken);
        if (campaignToUpdate is null) return Result.Fail(new SaxNotFoundException(nameof(Campaign), campaignDto.Id).Message);
        _mapper.Map(campaignDto, campaignToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Marketing.Campaign>().UpdateAsync(campaignToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}