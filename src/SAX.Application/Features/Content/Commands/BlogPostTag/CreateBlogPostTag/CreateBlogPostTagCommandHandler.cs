using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPostTag.CreateBlogPostTag;

public class CreateBlogPostTagCommandHandler : IRequestHandler<CreateBlogPostTagCommand, Result<Guid>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateBlogPostTagCommand> _validator;

    public CreateBlogPostTagCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateBlogPostTagCommand> validator)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateBlogPostTagCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createBlogPostTagDto = request.CreateBlogPostTagDto;
        var blogPostTag = _mapper.Map<Domain.Entities.Content.BlogPostTag>(createBlogPostTagDto);

        await _unitOfWork.Repository<Domain.Entities.Content.BlogPostTag>().AddAsync(blogPostTag, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(blogPostTag.Id);
    }
}