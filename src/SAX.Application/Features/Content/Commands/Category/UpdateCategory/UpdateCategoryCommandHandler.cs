using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCategoryCommand> _validator;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCategoryCommand> validator)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateCategoryDto = request.UpdateCategoryDto;
        var categoryToUpdate = await _unitOfWork.Repository<Domain.Entities.Content.Category>().GetByIdAsync(updateCategoryDto.Id, cancellationToken);
        if (categoryToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Category), updateCategoryDto.Id).Message);
        _mapper.Map(updateCategoryDto, categoryToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Content.Category>().UpdateAsync(categoryToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}