using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Commands.Media.CreateMedia;

public abstract record CreateMediaCommand(CreateMediaDto CreateMediaDto) : IRequest<Result<Guid>>;