using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Page.DeletePage;

public abstract record DeletePageCommand(Guid Id) : IRequest<Result>;