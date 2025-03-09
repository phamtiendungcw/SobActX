using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

public class PageRepository : GenericRepository<Page>, IPageRepository
{
    public PageRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }
}