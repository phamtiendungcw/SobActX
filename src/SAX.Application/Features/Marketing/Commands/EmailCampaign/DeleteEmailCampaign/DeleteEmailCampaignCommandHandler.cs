using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.DeleteEmailCampaign;

public class DeleteEmailCampaignCommandHandler : IRequestHandler<DeleteEmailCampaignCommand, Result>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository, IUnitOfWork unitOfWork)
    {
        _emailCampaignRepository = emailCampaignRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteEmailCampaignCommand request, CancellationToken cancellationToken)
    {
        var emailCampaignToDelete = await _unitOfWork.Repository<Domain.Entities.Marketing.EmailCampaign>().GetByIdAsync(request.Id, cancellationToken);
        if (emailCampaignToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(EmailCampaign), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailCampaign>().DeleteAsync(emailCampaignToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}