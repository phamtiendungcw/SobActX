using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

public interface ICampaignRepository : IGenericRepository<Campaign>
{
    /// <summary>
    ///     Liệt kê các chiến dịch đang hoạt động (chưa kết thúc).
    /// </summary>
    Task<IReadOnlyList<Campaign>> GetActiveCampaignsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các chiến dịch trong một khoảng thời gian cụ thể (cho báo cáo marketing).
    /// </summary>
    Task<IReadOnlyList<Campaign>> ListCampaignsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy chiến dịch theo tên chiến dịch (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<Campaign?> GetCampaignByNameAsync(string campaignName, CancellationToken cancellationToken = default);
}