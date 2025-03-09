using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

/// <summary>
///     Interface cho repository của entity EmailCampaign.
/// </summary>
public interface IEmailCampaignRepository : IGenericRepository<EmailCampaign>
{
    /// <summary>
    ///     Lấy danh sách các EmailCampaign theo CampaignId một cách bất đồng bộ.
    /// </summary>
    /// <param name="campaignId">Id của Campaign.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách EmailCampaign theo CampaignId.</returns>
    Task<IReadOnlyList<EmailCampaign>> GetEmailCampaignsByCampaignAsync(Guid campaignId, CancellationToken cancellationToken = default);
}