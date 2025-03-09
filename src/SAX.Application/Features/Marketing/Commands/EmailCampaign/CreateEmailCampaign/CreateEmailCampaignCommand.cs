using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public record CreateEmailCampaignCommand : IRequest<Result<Guid>>
{
    public CreateEmailCampaignDto? CreateEmailCampaignDto { get; set; }
}