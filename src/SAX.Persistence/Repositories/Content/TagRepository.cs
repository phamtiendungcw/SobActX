using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

/// <summary>
///     Repository cho entity Tag.
/// </summary>
public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    /// <summary>
    ///     Khởi tạo một instance của TagRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public TagRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Tag?> GetTagByNameAsync(string tagName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(t => t.TagName == tagName && !t.IsDeleted && t.IsActive, cancellationToken);
    }
}