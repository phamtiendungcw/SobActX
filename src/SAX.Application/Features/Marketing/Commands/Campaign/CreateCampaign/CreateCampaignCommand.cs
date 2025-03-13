using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.Campaign;

namespace SAX.Application.Features.Marketing.Commands.Campaign.CreateCampaign;

public abstract record CreateCampaignCommand(CreateCampaignDto CreateCampaignDto) : IRequest<Result<Guid>>;