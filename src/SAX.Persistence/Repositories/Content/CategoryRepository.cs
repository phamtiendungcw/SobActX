using SAX.Application.Common.Contracts.Persistence.Repositories.Content;
using SAX.Domain.Entities.Content;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Content;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    /// <summary>
    ///     Khởi tạo một instance của CategoryRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public CategoryRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }
}