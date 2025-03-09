using FluentResults;

using MediatR;

using SAX.Application.Features.Users.DTOs.User;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public record UpdateUserCommand : IRequest<Result>
{
    public UpdateUserDto? UpdateUserDto { get; set; }
}