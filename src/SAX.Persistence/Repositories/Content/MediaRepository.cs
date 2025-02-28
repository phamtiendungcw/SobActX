using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;

public class MediaRepository : GenericRepository<Media>, IMediaRepository
{
    public MediaRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Media>> ListMediaByTypeAsync(string mediaType, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Media
            .Where(m => m.MediaType == mediaType)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Media>> SearchMediaByFilenameAsync(string filename, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Media
            .Where(m => m.FileName.Contains(filename))
            .ToListAsync(cancellationToken);
    }
}