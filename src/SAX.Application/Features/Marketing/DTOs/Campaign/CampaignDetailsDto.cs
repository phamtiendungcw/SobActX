using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.DTOs.Campaign;

public class CampaignDetailsDto : CampaignDto
{
    public List<EmailCampaignDto> EmailCampaigns { get; set; } = new();
}