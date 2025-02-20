using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface IMediaRepository : IGenericRepository<Media>
{
    /// <summary>
    ///     Liệt kê các media theo loại media (ví dụ: hình ảnh, video).
    /// </summary>
    Task<IReadOnlyList<Media>> ListMediaByTypeAsync(string mediaType, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tìm kiếm media theo tên file.
    /// </summary>
    Task<IReadOnlyList<Media>> SearchMediaByFilenameAsync(string filename, CancellationToken cancellationToken = default);
}