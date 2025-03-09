using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

/// <summary>
///     Repository cho entity Segment.
/// </summary>
public class SegmentRepository : GenericRepository<Segment>, ISegmentRepository
{
    /// <summary>
    ///     Khởi tạo một instance của SegmentRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public SegmentRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<Segment?> GetSegmentByNameAsync(string segmentName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Segments.FirstOrDefaultAsync(s => s.SegmentName == segmentName && !s.IsDeleted && s.IsActive, cancellationToken);
    }
}