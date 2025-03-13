using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Tag;

namespace SAX.Application.Features.Content.Commands.Tag.CreateTag;

public abstract record CreateTagCommand(CreateTagDto CreateTagDto) : IRequest<Result<Guid>>;