using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.DTOs.Segment;

public class SegmentDetailsDto : SegmentDto
{
    public List<EmailCampaignDto> EmailCampaigns { get; set; } = new();
}