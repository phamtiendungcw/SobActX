using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.DeletePage;

public class DeletePageCommandHandler : IRequestHandler<DeletePageCommand, Result>
{
    private readonly IPageRepository _pageRepository;

    public DeletePageCommandHandler(IPageRepository pageRepository)
    {
        _pageRepository = pageRepository;
    }

    public async Task<Result> Handle(DeletePageCommand request, CancellationToken cancellationToken)
    {
        var pageToDelete = await _pageRepository.GetByIdAsync(request.Id, cancellationToken);
        if (pageToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Page), request.Id).Message);

        await _pageRepository.DeleteAsync(pageToDelete, cancellationToken);

        return Result.Ok();
    }
}