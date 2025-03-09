using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Result>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCampaignCommand> _validator;

    public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper, IValidator<UpdateCampaignCommand> validator)
    {
        _campaignRepository = campaignRepository;
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
        if (campaignDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật chiến dịch không hợp lệ: UpdateCampaignDto không được null.").Message);
        var campaignToUpdate = await _campaignRepository.GetByIdAsync(campaignDto.Id, cancellationToken);
        if (campaignToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.Campaign), campaignDto.Id).Message);

        _mapper.Map(campaignDto, campaignToUpdate);
        await _campaignRepository.UpdateAsync(campaignToUpdate, cancellationToken);

        return Result.Ok();
    }
}