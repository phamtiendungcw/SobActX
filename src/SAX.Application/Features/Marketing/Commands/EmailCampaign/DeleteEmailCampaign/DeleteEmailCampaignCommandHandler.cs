using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.DeleteEmailCampaign;

public class DeleteEmailCampaignCommandHandler : IRequestHandler<DeleteEmailCampaignCommand, Result>
{
    private readonly IEmailCampaignRepository _emailCampaignRepository;

    public DeleteEmailCampaignCommandHandler(IEmailCampaignRepository emailCampaignRepository)
    {
        _emailCampaignRepository = emailCampaignRepository;
    }

    public async Task<Result> Handle(DeleteEmailCampaignCommand request, CancellationToken cancellationToken)
    {
        var emailCampaignToDelete = await _emailCampaignRepository.GetByIdAsync(request.Id, cancellationToken);
        if (emailCampaignToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.EmailCampaign), request.Id).Message);
        await _emailCampaignRepository.DeleteAsync(emailCampaignToDelete, cancellationToken);

        return Result.Ok();
    }
}