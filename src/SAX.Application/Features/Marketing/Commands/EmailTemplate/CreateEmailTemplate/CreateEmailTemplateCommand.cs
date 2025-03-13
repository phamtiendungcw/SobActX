using FluentResults;

using MediatR;

using SAX.Application.Features.Marketing.DTOs.EmailTemplate;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.CreateEmailTemplate;

public abstract record CreateEmailTemplateCommand(CreateEmailTemplateDto CreateEmailTemplateDto) : IRequest<Result<Guid>>;