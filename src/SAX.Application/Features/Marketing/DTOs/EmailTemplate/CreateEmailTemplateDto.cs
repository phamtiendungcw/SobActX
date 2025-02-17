namespace SAX.Application.Features.Marketing.DTOs.EmailTemplate;

public class CreateEmailTemplateDto
{
    public string TemplateName { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string? Body { get; set; }
}