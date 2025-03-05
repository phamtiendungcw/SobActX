using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public record UpdatePageCommand : IRequest<Result>
{
    public UpdatePageDto? UpdatePageDto { get; set; }
}