namespace SAX.Application.Features.Marketing.DTOs.EmailTemplate;

public class UpdateEmailTemplateDto
{
    public Guid EmailTemplateId { get; set; }
    public string? TemplateName { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}