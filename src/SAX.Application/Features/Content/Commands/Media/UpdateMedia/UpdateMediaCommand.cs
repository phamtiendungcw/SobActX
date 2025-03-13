using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Media;

namespace SAX.Application.Features.Content.Commands.Media.UpdateMedia;

public abstract record UpdateMediaCommand(UpdateMediaDto UpdateMediaDto) : IRequest<Result>;