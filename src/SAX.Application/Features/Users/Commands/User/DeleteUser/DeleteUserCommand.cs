using FluentResults;

using MediatR;

namespace SAX.Application.Features.Users.Commands.User.DeleteUser;

public record DeleteUserCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}