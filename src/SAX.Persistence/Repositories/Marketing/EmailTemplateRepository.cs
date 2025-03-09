using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;
using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

/// <summary>
///     Repository cho entity EmailTemplate.
/// </summary>
public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
{
    /// <summary>
    ///     Khởi tạo một instance của EmailTemplateRepository.
    /// </summary>
    /// <param name="dbContext">DbContext của ứng dụng.</param>
    public EmailTemplateRepository(SaxDbContext dbContext) : base(dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<EmailTemplate?> GetEmailTemplateByNameAsync(string templateName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.EmailTemplates.FirstOrDefaultAsync(et => et.TemplateName == templateName && !et.IsDeleted && et.IsActive, cancellationToken);
    }
}