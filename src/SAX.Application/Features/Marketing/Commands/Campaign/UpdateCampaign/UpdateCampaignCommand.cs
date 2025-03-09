using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public record UpdateCampaignCommand : IRequest<Result>
{
    public UpdateCampaignDto? UpdateCampaignDto { get; set; }
}