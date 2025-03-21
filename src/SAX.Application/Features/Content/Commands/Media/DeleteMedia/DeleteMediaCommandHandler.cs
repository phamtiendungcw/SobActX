﻿using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Media.DeleteMedia;

public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, Result>
{
    private readonly IMediaRepository _mediaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMediaCommandHandler(IMediaRepository mediaRepository, IUnitOfWork unitOfWork)
    {
        _mediaRepository = mediaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var mediaToDelete = await _unitOfWork.Repository<Domain.Entities.Content.Media>().GetByIdAsync(request.Id, cancellationToken);
        if (mediaToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Media), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Content.Media>().DeleteAsync(mediaToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}