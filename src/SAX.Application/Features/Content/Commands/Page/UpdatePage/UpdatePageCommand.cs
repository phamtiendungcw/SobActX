using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public abstract record UpdatePageCommand(UpdatePageDto UpdatePageDto) : IRequest<Result>;