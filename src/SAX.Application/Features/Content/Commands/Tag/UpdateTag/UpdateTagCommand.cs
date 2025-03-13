using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Commands.Tag.UpdateTag;

public abstract record UpdateTagCommand(UpdateTagDto UpdateTagDto) : IRequest<Result>;