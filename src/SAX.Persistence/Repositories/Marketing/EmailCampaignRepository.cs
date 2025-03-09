using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;

public class EmailCampaignRepository : GenericRepository<EmailCampaign>, IEmailCampaignRepository
{
    public EmailCampaignRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<EmailCampaign>> ListEmailCampaignsForCampaignAsync(Guid campaignId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.EmailCampaigns
            .Where(ec => ec.CampaignId == campaignId)
            .Include(ec => ec.Campaign) // Eager load Campaign, EmailTemplate và Segment
            .Include(ec => ec.EmailTemplate)
            .Include(ec => ec.Segment)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<EmailCampaign>> ListLatestSentEmailCampaignsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Cần thêm trường "SentDate" vào Entity EmailCampaign để có thể order by date
        // Code mẫu này chỉ trả về latest email campaigns dựa trên ID (không đúng logic "sent date")
        return await _dbContext.EmailCampaigns
            .OrderByDescending(ec => ec.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}