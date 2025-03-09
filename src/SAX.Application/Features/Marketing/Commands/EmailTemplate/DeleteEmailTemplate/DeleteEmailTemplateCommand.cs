using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.DeleteEmailTemplate;

public record DeleteEmailTemplateCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}