using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public record CreateCampaignCommand : IRequest<Result<Guid>>
{
    public CreateCampaignDto? CreateCampaignDto { get; set; }
}