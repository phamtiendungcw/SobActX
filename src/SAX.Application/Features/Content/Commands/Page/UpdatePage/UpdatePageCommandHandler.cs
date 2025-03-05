using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    private readonly IValidator<UpdatePageCommand> _validator;

    public UpdatePageCommandHandler(IPageRepository pageRepository, IMapper mapper, IValidator<UpdatePageCommand> validator)
    {
        _pageRepository = pageRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updatePageDto = request.UpdatePageDto;
        if (updatePageDto == null) return Result.Fail("UpdatePageDto cannot be null.");
        var pageToUpdate = await _pageRepository.GetByIdAsync(updatePageDto.PageId, cancellationToken);
        if (pageToUpdate == null) return Result.Fail($"Không tìm thấy trang với ID: {updatePageDto.PageId}");
        _mapper.Map(request.UpdatePageDto, pageToUpdate);
        await _pageRepository.UpdateAsync(pageToUpdate, cancellationToken);

        return Result.Ok();
    }
}