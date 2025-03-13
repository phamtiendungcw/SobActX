using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.CreateEmailCampaign;

public abstract record CreateEmailCampaignCommand(CreateEmailCampaignDto CreateEmailCampaignDto) : IRequest<Result<Guid>>;