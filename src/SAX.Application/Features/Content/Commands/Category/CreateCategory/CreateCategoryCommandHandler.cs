using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Category.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryCommand> _validator;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IValidator<CreateCategoryCommand> validator)
    {
        _mapper = mapper;
        _validator = validator;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createCategoryDto = request.CreateCategoryDto;
        var categoryToCreate = _mapper.Map<Domain.Entities.Content.Category>(createCategoryDto);
        var createdCategory = await _categoryRepository.AddAsync(categoryToCreate, cancellationToken);

        return Result.Ok(createdCategory.Id);
    }
}