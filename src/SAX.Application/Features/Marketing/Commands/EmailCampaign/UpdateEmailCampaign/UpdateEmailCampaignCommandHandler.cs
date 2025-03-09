using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public class UpdateEmailCampaignCommandHandler : IRequestHandler<UpdateEmailCampaignCommand, Result>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateEmailCampaignCommand> _validator;
    public UpdateEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository, IMapper mapper, IValidator<UpdateEmailCampaignCommand> validator)
    {
        _emailCampaignRepository = emailCampaignRepository;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task<Result> Handle(UpdateEmailCampaignCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }
        var updateEmailCampaignDto = request.UpdateEmailCampaignDto;
        if (updateEmailCampaignDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật chiến dịch email không hợp lệ: UpdateEmailCampaignDto không được null.").Message);

        var emailCampaignToUpdate = await _emailCampaignRepository.GetByIdAsync(updateEmailCampaignDto.Id, cancellationToken);
        if (emailCampaignToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.EmailCampaign), updateEmailCampaignDto.Id).Message);

        _mapper.Map(request.UpdateEmailCampaignDto, emailCampaignToUpdate);
        await _emailCampaignRepository.UpdateAsync(emailCampaignToUpdate, cancellationToken);

        return Result.Ok();
    }
}