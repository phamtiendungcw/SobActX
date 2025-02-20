using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

public interface ISegmentRepository : IGenericRepository<Segment>
{
    /// <summary>
    ///     Lấy segment theo tên segment (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<Segment?> GetSegmentByNameAsync(string segmentName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các segment phổ biến nhất (dựa trên số lượng email campaign sử dụng segment đó - cần thêm trường Count vào
    ///     Entity nếu muốn thống kê).
    /// </summary>
    Task<IReadOnlyList<Segment>> ListPopularSegmentsAsync(int count, CancellationToken cancellationToken = default);
}