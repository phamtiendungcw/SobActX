﻿using FluentResults;

using MediatR;

using SAX.Application.Features.Content.DTOs.Page;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public record CreatePageCommand : IRequest<Result<Guid>>
{
    public CreatePageDto? CreatePageDto { get; set; }
}