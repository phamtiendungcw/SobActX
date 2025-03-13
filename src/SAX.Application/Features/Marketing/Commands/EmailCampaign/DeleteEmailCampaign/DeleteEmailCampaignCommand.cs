using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.DeleteEmailCampaign;

public abstract record DeleteEmailCampaignCommand(Guid Id) : IRequest<Result>;