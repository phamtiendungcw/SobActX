using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Tag.DeleteTag;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, Result>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tagToDelete = await _tagRepository.GetByIdAsync(request.Id, cancellationToken);
        if (tagToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Tag), request.Id).Message);

        await _tagRepository.DeleteAsync(tagToDelete, cancellationToken);

        return Result.Ok();
    }
}