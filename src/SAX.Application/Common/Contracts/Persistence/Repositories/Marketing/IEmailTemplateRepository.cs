using SAX.Domain.Entities.Marketing;

namespace SAX.Application.Common.Contracts.Persistence.Repositories.Marketing;

/// <summary>
///     Interface cho repository của entity EmailTemplate.
/// </summary>
public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
{
    /// <summary>
    ///     Lấy một EmailTemplate theo TemplateName một cách bất đồng bộ.
    /// </summary>
    /// <param name="templateName">TemplateName của EmailTemplate.</param>
    /// <param name="cancellationToken">Token hủy bỏ.</param>
    /// <returns>EmailTemplate nếu tìm thấy, ngược lại trả về null.</returns>
    Task<EmailTemplate?> GetEmailTemplateByNameAsync(string templateName, CancellationToken cancellationToken = default);
}