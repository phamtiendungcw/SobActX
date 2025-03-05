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
            return Result.Fail(new SobActXValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var updateBlogPostDto = request.UpdateBlogPostDto;
        if (updateBlogPostDto == null) return Result.Fail("Dữ liệu cập nhật bài viết blog không hợp lệ");
        var blogPostToUpdate = await _blogPostRepository.GetByIdAsync(updateBlogPostDto.BlogPostId, cancellationToken);
        if (blogPostToUpdate == null) return Result.Fail($"Không tìm thấy bài viết blog với ID: {updateBlogPostDto.BlogPostId}");
        _mapper.Map(updateBlogPostDto, blogPostToUpdate);

        //// Cập nhật Tags (nếu TagIds được cung cấp trong UpdateBlogPostDto)
        //if (updateBlogPostDto.TagIds != null)
        //{
        //    blogPostToUpdate.Tags.Clear(); // Xóa tags cũ trước khi thêm tags mới
        //    var tagsToAdd = await _blogPostRepository.GetAllAsync<Tag>(t => request.UpdateBlogPostDto.TagIds.Contains(t.Id), cancellationToken); // Lấy Tags từ DB
        //    foreach (var tag in tagsToAdd) blogPostToUpdate.Tags.Add(tag);
        //}

        //if (updateBlogPostDto.TagIds != null)
        //{
        //    blogPostToUpdate.Tags.Clear();
        //    // Sử dụng ListAllAsync để lấy tất cả Tags và lọc trong code
        //    var allTags = await _blogPostRepository.ListAllAsync(cancellationToken);
        //    var tagsToAdd = allTags.Where(t => updateBlogPostDto.TagIds.Contains(t.Id)).ToList(); // Lọc
        //    foreach (var tag in tagsToAdd) blogPostToUpdate.Tags.Add(tag);
        //}

        await _blogPostRepository.UpdateAsync(blogPostToUpdate, cancellationToken);

        return Result.Ok();
    }
}