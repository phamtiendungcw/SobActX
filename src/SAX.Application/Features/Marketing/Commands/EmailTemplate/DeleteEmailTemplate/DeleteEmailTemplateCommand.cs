using FluentResults;

using MediatR;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.DeleteEmailTemplate;

public abstract record DeleteEmailTemplateCommand(Guid Id) : IRequest<Result>;