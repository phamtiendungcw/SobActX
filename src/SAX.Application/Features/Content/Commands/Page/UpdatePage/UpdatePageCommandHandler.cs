using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.Page.UpdatePage;

public class UpdatePageCommandHandler : IRequestHandler<UpdatePageCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IPageRepository _pageRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdatePageCommand> _validator;

    public UpdatePageCommandHandler(IPageRepository pageRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePageCommand> validator)
    {
        _pageRepository = pageRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updatePageDto = request.UpdatePageDto;
        var pageToUpdate = await _unitOfWork.Repository<Domain.Entities.Content.Page>().GetByIdAsync(updatePageDto.Id, cancellationToken);
        if (pageToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.Page), updatePageDto.Id).Message);
        _mapper.Map(updatePageDto, pageToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Content.Page>().UpdateAsync(pageToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}