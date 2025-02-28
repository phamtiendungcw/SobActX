using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;

public class SegmentRepository : GenericRepository<Segment>, ISegmentRepository
{
    public SegmentRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Segment?> GetSegmentByNameAsync(string segmentName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Segments.FirstOrDefaultAsync(s => s.SegmentName == segmentName, cancellationToken);
    }

    public async Task<IReadOnlyList<Segment>> ListPopularSegmentsAsync(int count, CancellationToken cancellationToken = default)
    {
        // Cần implement logic để xác định độ phổ biến (ví dụ: dựa trên số lượng email campaigns sử dụng segment đó)
        // Code mẫu này chỉ trả về latest segments dựa trên ID (không đúng logic "popularity")
        return await _dbContext.Segments
            .OrderByDescending(s => s.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}