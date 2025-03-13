using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public abstract record CreatePageCommand(CreatePageDto CreatePageDto) : IRequest<Result<Guid>>;