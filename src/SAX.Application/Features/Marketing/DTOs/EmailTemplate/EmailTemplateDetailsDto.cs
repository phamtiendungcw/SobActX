using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.DTOs.EmailTemplate;

public class EmailTemplateDetailsDto : EmailTemplateDto
{
    public List<EmailCampaignDto> EmailCampaigns { get; set; } = new();
}