namespace SAX.Domain.Entities.Marketing;

public class EmailCampaign : BaseEntity
{
    public Guid CampaignId { get; set; } // Foreign key to Campaign
    public Campaign? Campaign { get; set; }
    public Guid EmailTemplateId { get; set; } // Foreign key to EmailTemplate
    public EmailTemplate? EmailTemplate { get; set; }
    public Guid? SegmentId { get; set; } // Foreign key to Segment, optional segment
    public Segment? Segment { get; set; }
}