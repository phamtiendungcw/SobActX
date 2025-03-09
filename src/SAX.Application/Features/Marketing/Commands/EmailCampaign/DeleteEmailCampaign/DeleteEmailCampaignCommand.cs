using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.EmailCampaign.DeleteEmailCampaign;

public record DeleteEmailCampaignCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}