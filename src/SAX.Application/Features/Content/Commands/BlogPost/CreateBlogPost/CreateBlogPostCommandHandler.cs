using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Result<Guid>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateBlogPostCommand> _validator;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateBlogPostCommand> validator)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var blogPostDto = request.CreateBlogPostDto;
        var blogPost = _mapper.Map<Domain.Entities.Content.BlogPost>(blogPostDto);

        await _unitOfWork.Repository<Domain.Entities.Content.BlogPost>().AddAsync(blogPost, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(blogPost.Id);
    }
}