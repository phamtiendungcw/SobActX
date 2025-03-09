using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.Campaign.DeleteCampaign;

public record DeleteCampaignCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}