using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.DeleteCampaign;

public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, Result>
{
    private readonly ICampaignRepository _campaignRepository;

    public DeleteCampaignCommandHandler(ICampaignRepository campaignRepository)
    {
        _campaignRepository = campaignRepository;
    }

    public async Task<Result> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaignToDelete = await _campaignRepository.GetByIdAsync(request.Id, cancellationToken);
        if (campaignToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.Campaign), request.Id).Message);
        await _campaignRepository.DeleteAsync(campaignToDelete, cancellationToken);

        return Result.Ok();
    }
}