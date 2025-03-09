using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPost.CreateBlogPost;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Result<Guid>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBlogPostCommand> _validator;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper, IValidator<CreateBlogPostCommand> validator)
    {
        _blogPostRepository = blogPostRepository;
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

        var createBlogPostDto = request.CreateBlogPostDto;
        var blogPostToCreate = _mapper.Map<Domain.Entities.Content.BlogPost>(createBlogPostDto);
        var createdBlogPost = await _blogPostRepository.CreateAsync(blogPostToCreate, cancellationToken);

        return Result.Ok(createdBlogPost.Id);
    }
}