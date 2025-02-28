using AutoMapper;

using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;

namespace SAX.Application.Features.Content.Commands.CreateBlogPost;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, Result<Guid>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPostToCreate = _mapper.Map<BlogPost>(request.CreateBlogPostDto);
        await _blogPostRepository.AddAsync(blogPostToCreate, cancellationToken);

        return Result.Ok(blogPostToCreate.Id);
    }
}