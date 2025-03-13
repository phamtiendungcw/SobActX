using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.Campaign.DeleteCampaign;

public abstract record DeleteCampaignCommand(Guid Id) : IRequest<Result>;