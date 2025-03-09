using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

public class MediaRepository : GenericRepository<Media>, IMediaRepository
{
    public MediaRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }
}