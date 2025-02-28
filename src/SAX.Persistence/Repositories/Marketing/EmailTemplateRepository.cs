using SAX.Persistence.DatabaseContext;

namespace SAX.Persistence.Repositories.Marketing;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;
using SAX.Domain.Entities.Marketing;

public class EmailTemplateRepository : GenericRepository<EmailTemplate>, IEmailTemplateRepository
{
    public EmailTemplateRepository(SobActXDatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<EmailTemplate?> GetEmailTemplateByNameAsync(string templateName, CancellationToken cancellationToken = default)
    {
        return await _dbContext.EmailTemplates.FirstOrDefaultAsync(et => et.TemplateName == templateName, cancellationToken);
    }

    public async Task<IReadOnlyList<EmailTemplate>> ListLatestUsedEmailTemplatesAsync(int count, CancellationToken cancellationToken = default)
    {
        // Cần implement logic để xác định "lần sử dụng gần đây nhất" (ví dụ: dựa trên ngày tạo EmailCampaign gần nhất sử dụng template đó)
        // Code mẫu này chỉ trả về latest email templates dựa trên ID (không đúng logic "last used")
        return await _dbContext.EmailTemplates
            .OrderByDescending(et => et.Id)
            .Take(count)
            .ToListAsync(cancellationToken);
    }
}