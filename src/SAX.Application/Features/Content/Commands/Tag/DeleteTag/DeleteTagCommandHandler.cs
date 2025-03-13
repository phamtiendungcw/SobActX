using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Tag.DeleteTag;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result>
{
    private readonly ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTagCommandHandler(ITagRepository tagRepository, IUnitOfWork unitOfWork)
    {
        _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tagToDelete = await _unitOfWork.Repository<Domain.Entities.Content.Tag>().GetByIdAsync(request.Id, cancellationToken);
        if (tagToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Tag), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Content.Tag>().DeleteAsync(tagToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}