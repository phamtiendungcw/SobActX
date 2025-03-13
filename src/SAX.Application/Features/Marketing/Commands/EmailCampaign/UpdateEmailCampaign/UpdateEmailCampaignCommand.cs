using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.UpdateEmailCampaign;

public abstract record UpdateEmailCampaignCommand(UpdateEmailCampaignDto UpdateEmailCampaignDto) : IRequest<Result>;