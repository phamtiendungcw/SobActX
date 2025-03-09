using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Content.Commands.BlogPost.UpdateBlogPost;

public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, Result>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateBlogPostCommand> _validator;

    public UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper, IValidator<UpdateBlogPostCommand> validator)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateBlogPostDto = request.UpdateBlogPostDto;
        if (updateBlogPostDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật bài viết blog không hợp lệ: UpdateBlogPostDto không được null.").Message);

        var blogPostToUpdate = await _blogPostRepository.GetByIdAsync(updateBlogPostDto.Id, cancellationToken);
        if (blogPostToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Content.BlogPost), updateBlogPostDto.Id).Message);

        _mapper.Map(updateBlogPostDto, blogPostToUpdate);
        await _blogPostRepository.UpdateAsync(blogPostToUpdate, cancellationToken);

        return Result.Ok();
    }
}