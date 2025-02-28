using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;

public class PageRepository : GenericRepository<Page>, IPageRepository
{
    public PageRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Page?> GetPageBySlugAsync(string slug, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Pages.FirstOrDefaultAsync(p => p.Slug == slug, cancellationToken);
    }

    public async Task<IReadOnlyList<Page>> ListLatestPublishedPagesAsync(int count, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Pages
            .OrderByDescending(p => p.PublishDate)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}