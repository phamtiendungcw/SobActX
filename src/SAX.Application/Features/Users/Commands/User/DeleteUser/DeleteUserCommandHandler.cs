using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Users.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _unitOfWork.Repository<Domain.Entities.Users.User>().GetByIdAsync(request.Id, cancellationToken);
        if (userToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(User), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Users.User>().DeleteAsync(userToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}