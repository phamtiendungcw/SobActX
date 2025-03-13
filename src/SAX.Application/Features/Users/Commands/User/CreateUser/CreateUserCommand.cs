using FluentResults;

using MediatR;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Commands.User.CreateUser;

public abstract record CreateUserCommand(CreateUserDto CreateUserDto) : IRequest<Result<Guid>>;