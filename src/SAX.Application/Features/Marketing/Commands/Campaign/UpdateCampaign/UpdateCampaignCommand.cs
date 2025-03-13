using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Commands.Campaign.UpdateCampaign;

public abstract record UpdateCampaignCommand(UpdateCampaignDto UpdateCampaignDto) : IRequest<Result>;