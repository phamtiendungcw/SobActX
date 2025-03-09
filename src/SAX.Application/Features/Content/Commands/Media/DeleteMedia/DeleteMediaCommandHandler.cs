using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.DeleteMedia;

public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, Result>
{
    private readonly IMediaRepository _mediaRepository;

    public DeleteMediaCommandHandler(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    public async Task<Result> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var mediaToDelete = await _mediaRepository.GetByIdAsync(request.Id, cancellationToken);
        if (mediaToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Media), request.Id).Message);

        await _mediaRepository.DeleteAsync(mediaToDelete, cancellationToken);

        return Result.Ok();
    }
}