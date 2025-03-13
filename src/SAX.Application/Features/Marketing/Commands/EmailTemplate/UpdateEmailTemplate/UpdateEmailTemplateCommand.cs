using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.UpdateEmailTemplate;

public abstract record UpdateEmailTemplateCommand(UpdateEmailTemplateDto UpdateEmailTemplateDto) : IRequest<Result>;