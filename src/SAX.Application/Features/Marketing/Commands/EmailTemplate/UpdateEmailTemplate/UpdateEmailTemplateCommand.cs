using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public record UpdateEmailTemplateCommand : IRequest<Result>
{
    public UpdateEmailTemplateDto? UpdateEmailTemplateDto { get; set; }
}