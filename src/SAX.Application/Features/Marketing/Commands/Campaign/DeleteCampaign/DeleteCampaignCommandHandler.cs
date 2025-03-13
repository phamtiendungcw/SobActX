using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.Campaign.DeleteCampaign;

public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, Result>
{
    private readonly ICampaignRepository _campaignRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCampaignCommandHandler(ICampaignRepository campaignRepository, IUnitOfWork unitOfWork)
    {
        _campaignRepository = campaignRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaignToDelete = await _unitOfWork.Repository<Domain.Entities.Marketing.Campaign>().GetByIdAsync(request.Id, cancellationToken);
        if (campaignToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Campaign), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Marketing.Campaign>().DeleteAsync(campaignToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}