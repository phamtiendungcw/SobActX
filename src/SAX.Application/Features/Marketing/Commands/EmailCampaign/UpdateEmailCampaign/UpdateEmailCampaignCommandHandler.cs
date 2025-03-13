using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public class UpdateEmailCampaignCommandHandler : IRequestHandler<UpdateEmailCampaignCommand, Result>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateEmailCampaignCommand> _validator;

    public UpdateEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository, IUnitOfWork unitOfWork, IMapper mapper,
        IValidator<UpdateEmailCampaignCommand> validator)
    {
        _emailCampaignRepository = emailCampaignRepository;
        _unitOfWork = unitOfWork;
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

        var emailCampaignDto = request.UpdateEmailCampaignDto;
        var emailCampaign = await _unitOfWork.Repository<Domain.Entities.Marketing.EmailCampaign>().GetByIdAsync(emailCampaignDto.Id, cancellationToken);
        if (emailCampaign == null) return Result.Fail(new SaxNotFoundException(nameof(EmailCampaign), emailCampaignDto.Id).Message);
        _mapper.Map(emailCampaignDto, emailCampaign);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailCampaign>().UpdateAsync(emailCampaign, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}