using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

/// <summary>
///     Repository cho entity Campaign.
/// </summary>
public class CampaignRepository : GenericRepository<Campaign>, ICampaignRepository
{
    /// <summary>
    ///     Khởi tạo một instance của CampaignRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public CampaignRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Campaign>> GetActiveCampaignsAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Campaigns
            .Where(c => c.StartDate <= DateTime.UtcNow && (!c.EndDate.HasValue || c.EndDate > DateTime.UtcNow) && !c.IsDeleted && c.IsActive)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<Campaign>> GetCampaignsEndingSoonAsync(int days, CancellationToken cancellationToken = default)
    {
        var endDateThreshold = DateTime.UtcNow.AddDays(days);
        return await _dbContext.Campaigns
            .Where(c => c.EndDate.HasValue && c.EndDate <= endDateThreshold && c.EndDate > DateTime.UtcNow && !c.IsDeleted && c.IsActive)
            .ToListAsync(cancellationToken);
    }
}