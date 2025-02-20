using SAX.Domain.Entities.Content;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Content;

public interface ICategoryRepository : IGenericRepository<Category>
{
    /// <summary>
    ///     Lấy danh mục theo tên danh mục (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<Category?> GetCategoryByNameAsync(string categoryName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê tất cả các danh mục, bao gồm cả số lượng bài viết blog trong mỗi danh mục (cho dashboard).
    /// </summary>
    Task<IReadOnlyList<Category>> ListCategoriesWithBlogPostCountsAsync(CancellationToken cancellationToken = default);
}