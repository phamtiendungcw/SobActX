namespace SAX.Application.Features.Marketing.DTOs.EmailCampaign;

public class EmailCampaignDetailsDto : EmailCampaignDto
{
    public string CampaignName { get; set; } = string.Empty;
    public string TemplateName { get; set; } = string.Empty;
    public string? SegmentName { get; set; }
}