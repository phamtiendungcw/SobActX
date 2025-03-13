using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.DeletePage;

public class DeletePageCommandHandler : IRequestHandler<DeletePageCommand, Result>
{
    private readonly IPageRepository _pageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePageCommandHandler(IPageRepository pageRepository, IUnitOfWork unitOfWork)
    {
        _pageRepository = pageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePageCommand request, CancellationToken cancellationToken)
    {
        var pageToDelete = await _unitOfWork.Repository<Domain.Entities.Content.Page>().GetByIdAsync(request.Id, cancellationToken);
        if (pageToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Page), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Content.Page>().DeleteAsync(pageToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}