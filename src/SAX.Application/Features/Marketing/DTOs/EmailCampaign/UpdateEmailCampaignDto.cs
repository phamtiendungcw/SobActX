namespace SAX.Application.Features.Marketing.DTOs.EmailCampaign;

public class UpdateEmailCampaignDto
{
    public Guid EmailCampaignId { get; set; }
    public Guid? CampaignId { get; set; }
    public Guid? EmailTemplateId { get; set; }
    public Guid? SegmentId { get; set; }
}