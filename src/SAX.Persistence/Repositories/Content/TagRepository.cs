using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Tag?> GetTagByNameAsync(string tagName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Tags.FirstOrDefaultAsync(t => t.TagName == tagName, cancellationToken);
    }

    public async Task<IReadOnlyList<Tag>> ListPopularTagsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Ví dụ: Truy vấn phức tạp hơn, cần join bảng và group by
        // Code mẫu này chỉ trả về danh sách Tag đơn giản, bạn cần tùy chỉnh để tính Popular Tags
        return await ListAllAsync(cancellationToken);
    }
}