using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.UpdateBlogPostTag;

public class UpdateBlogPostTagCommandHandler : IRequestHandler<UpdateBlogPostTagCommand, Result>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateBlogPostTagCommand> _validator;

    public UpdateBlogPostTagCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateBlogPostTagCommand> validator)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateBlogPostTagCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateBlogPostTagDto = request.UpdateBlogPostTagDto;
        var blogPostTagToUpdate = await _unitOfWork.Repository<Domain.Entities.Content.BlogPostTag>().GetByIdAsync(updateBlogPostTagDto.Id, cancellationToken);
        if (blogPostTagToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.BlogPostTag), updateBlogPostTagDto.Id).Message);
        _mapper.Map(updateBlogPostTagDto, blogPostTagToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Content.BlogPostTag>().UpdateAsync(blogPostTagToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}