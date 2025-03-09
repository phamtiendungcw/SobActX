using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

/// <summary>
///     Repository cho entity EmailCampaign.
/// </summary>
public class EmailCampaignRepository : GenericRepository<EmailCampaign>, IEmailCampaignRepository
{
    /// <summary>
    ///     Khởi tạo một instance của EmailCampaignRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public EmailCampaignRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<EmailCampaign>> GetEmailCampaignsByCampaignAsync(Guid campaignId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.EmailCampaigns.Where(ec => ec.CampaignId == campaignId && !ec.IsDeleted && ec.IsActive).ToListAsync(cancellationToken);
    }
}