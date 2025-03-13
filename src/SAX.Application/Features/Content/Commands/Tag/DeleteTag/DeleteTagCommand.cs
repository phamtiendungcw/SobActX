using FluentResults;

using MediatR;

namespace SAX.Application.Features.Content.Commands.Tag.DeleteTag;

public abstract record DeleteTagCommand(Guid Id) : IRequest<Result>;