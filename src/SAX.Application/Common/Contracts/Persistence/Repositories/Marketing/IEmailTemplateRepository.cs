using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
{
    /// <summary>
    ///     Lấy email template theo tên template (cho mục đích kiểm tra tính duy nhất).
    /// </summary>
    Task<EmailTemplate?> GetEmailTemplateByNameAsync(string templateName, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Liệt kê các email templates được sử dụng gần đây nhất (cho dashboard marketing).
    /// </summary>
    Task<IReadOnlyList<EmailTemplate>> ListLatestUsedEmailTemplatesAsync(int count, CancellationToken cancellationToken = default);
}