using FluentResults;

using MediatR;

namespace SAX.Application.Features.Users.Commands.User.DeleteUser;

public abstract record DeleteUserCommand(Guid Id) : IRequest<Result>;