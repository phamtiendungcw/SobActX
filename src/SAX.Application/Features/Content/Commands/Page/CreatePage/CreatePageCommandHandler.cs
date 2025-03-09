using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    private readonly IValidator<CreatePageCommand> _validator;

    public CreatePageCommandHandler(IPageRepository pageRepository, IMapper mapper, IValidator<CreatePageCommand> validator)
    {
        _pageRepository = pageRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreatePageCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createPageDto = request.CreatePageDto;
        var pageToCreate = _mapper.Map<Domain.Entities.Content.Page>(createPageDto);
        var createdPage = await _pageRepository.AddAsync(pageToCreate, cancellationToken);

        return Result.Ok(createdPage.Id);
    }
}