using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

public interface IEmailCampaignRepository : IGenericRepository<EmailCampaign>
{
    /// <summary>
    ///     Liệt kê các email campaign theo ID chiến dịch.
    /// </summary>
    Task<IReadOnlyList<EmailCampaign>> ListEmailCampaignsForCampaignAsync(Guid campaignId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các email campaign được gửi gần đây nhất (cho dashboard marketing).
    /// </summary>
    Task<IReadOnlyList<EmailCampaign>> ListLatestSentEmailCampaignsAsync(int count, CancellationToken cancellationToken = default);
}