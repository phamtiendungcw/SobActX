using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

/// <summary>
///     Interface cho repository của entity Campaign.
/// </summary>
public interface ICampaignRepository : IGenericRepository<Campaign>
{
    /// <summary>
    ///     Lấy danh sách các campaign đang hoạt động một cách bất đồng bộ.
    /// </summary>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách các campaign đang hoạt động.</returns>
    Task<IReadOnlyList<Campaign>> GetActiveCampaignsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Lấy danh sách các campaign sắp kết thúc trong một khoảng thời gian nhất định một cách bất đồng bộ.
    /// </summary>
    /// <param name="days">Số ngày tới.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Danh sách các campaign sắp kết thúc.</returns>
    Task<IReadOnlyList<Campaign>> GetCampaignsEndingSoonAsync(int days, CancellationToken cancellationToken = default);
}