using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public record UpdateEmailCampaignCommand : IRequest<Result>
{
    public UpdateEmailCampaignDto? UpdateEmailCampaignDto { get; set; }
}