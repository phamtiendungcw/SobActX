using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.DeleteEmailTemplate;

public class DeleteEmailTemplateCommandHandler : IRequestHandler<DeleteEmailTemplateCommand, Result>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;

    public DeleteEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository)
    {
        _emailTemplateRepository = emailTemplateRepository;
    }

    public async Task<Result> Handle(DeleteEmailTemplateCommand request, CancellationToken cancellationToken)
    {
        var emailTemplateToDelete = await _emailTemplateRepository.GetByIdAsync(request.Id, cancellationToken);
        if (emailTemplateToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Marketing.EmailTemplate), request.Id).Message);
        await _emailTemplateRepository.DeleteAsync(emailTemplateToDelete, cancellationToken);

        return Result.Ok();
    }
}