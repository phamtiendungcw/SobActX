using FluentResults;

using MediatR;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public abstract record UpdateUserCommand(UpdateUserDto UpdateUserDto) : IRequest<Result>;