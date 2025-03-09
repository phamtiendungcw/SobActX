using FluentResults;

using MediatR;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Commands.User.CreateUser;

public record CreateUserCommand : IRequest<Result<Guid>>
{
    public CreateUserDto? CreateUserDto { get; set; }
}