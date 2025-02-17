using SAX.Application.Features.Marketing.DTOs.Campaign;
using SAX.Application.Features.Marketing.DTOs.EmailTemplate;
using SAX.Application.Features.Marketing.DTOs.Segment;

namespace SAX.Application.Features.Marketing.DTOs.EmailCampaign;

public class EmailCampaignDto
{
    public Guid EmailCampaignId { get; set; }
    public CampaignDto? Campaign { get; set; }
    public EmailTemplateDto? EmailTemplate { get; set; }
    public SegmentDto? Segment { get; set; }
}