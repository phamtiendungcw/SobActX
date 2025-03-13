using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Media.DeleteMedia;

public abstract record DeleteMediaCommand(Guid Id) : IRequest<Result>;