using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Marketing.Commands.EmailTemplate.DeleteEmailTemplate;

public class DeleteEmailTemplateCommandHandler : IRequestHandler<DeleteEmailTemplateCommand, Result>
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmailTemplateCommandHandler(IEmailTemplateRepository emailTemplateRepository, IUnitOfWork unitOfWork)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteEmailTemplateCommand request, CancellationToken cancellationToken)
    {
        var emailTemplateToDelete = await _unitOfWork.Repository<Domain.Entities.Marketing.EmailTemplate>().GetByIdAsync(request.Id, cancellationToken);
        if (emailTemplateToDelete is null) return Result.Fail(new SaxNotFoundException(nameof(EmailTemplate), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Marketing.EmailTemplate>().DeleteAsync(emailTemplateToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}