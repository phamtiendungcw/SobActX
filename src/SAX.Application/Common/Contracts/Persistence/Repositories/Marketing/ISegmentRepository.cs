using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

/// <summary>
///     Interface cho repository của entity Segment.
/// </summary>
public interface ISegmentRepository : IGenericRepository<Segment>
{
    /// <summary>
    ///     Lấy một Segment theo SegmentName một cách bất đồng bộ.
    /// </summary>
    /// <param name="segmentName">SegmentName của Segment.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>Segment nếu tìm thấy, ngược lại trả về null.</returns>
    Task<Segment?> GetSegmentByNameAsync(string segmentName, CancellationToken cancellationToken = default);
}