using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCategoryCommand> _validator;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IValidator<UpdateCategoryCommand> validator)
    {
        _categoryRepository = categoryRepository;
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
        if (updateCategoryDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật danh mục không hợp lệ: UpdateCategoryDto không được null.").Message);

        var categoryToUpdate = await _categoryRepository.GetByIdAsync(updateCategoryDto.Id, cancellationToken);
        if (categoryToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Category), updateCategoryDto.Id).Message);

        _mapper.Map(request.UpdateCategoryDto, categoryToUpdate);
        await _categoryRepository.UpdateAsync(categoryToUpdate, cancellationToken);

        return Result.Ok();
    }
}