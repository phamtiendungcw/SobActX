using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.CreatePage;

public class CreatePageCommandHandler : IRequestHandler<CreatePageCommand, Result<Guid>>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePageCommand> _validator;

    public CreatePageCommandHandler(IPageRepository pageRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePageCommand> validator)
    {
        _pageRepository = pageRepository;
        _unitOfWork = unitOfWork;
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
        var page = _mapper.Map<Domain.Entities.Content.Page>(createPageDto);

        await _unitOfWork.Repository<Domain.Entities.Content.Page>().AddAsync(page, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(page.Id);
    }
}