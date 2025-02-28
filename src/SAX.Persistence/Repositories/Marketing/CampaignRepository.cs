using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

public class CampaignRepository : GenericRepository<Campaign>, ICampaignRepository
{
    public CampaignRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Campaign>> GetActiveCampaignsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Campaigns
            .Where(c => c.StartDate <= DateTime.Now && (!c.EndDate.HasValue || c.EndDate >= DateTime.Now))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Campaign>> ListCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Campaigns
            .Where(c => c.StartDate >= startDate && c.EndDate <= endDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Campaign?> GetCampaignByNameAsync(string campaignName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Campaigns.FirstOrDefaultAsync(c => c.CampaignName == campaignName, cancellationToken);
    }
}