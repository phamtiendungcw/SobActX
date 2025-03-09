using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Users.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        if (userToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Users.User), request.Id).Message);

        await _userRepository.DeleteAsync(userToDelete, cancellationToken);

        return Result.Ok();
    }
}