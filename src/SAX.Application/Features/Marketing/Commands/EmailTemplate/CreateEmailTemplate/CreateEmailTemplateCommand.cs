using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;

public record CreateEmailTemplateCommand : IRequest<Result<Guid>>
{
    public CreateEmailTemplateDto? CreateEmailTemplateDto { get; set; }
}