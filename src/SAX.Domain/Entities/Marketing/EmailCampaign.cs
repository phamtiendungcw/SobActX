namespace SAX.Domain.Entities.Marketing;

public class EmailCampaign
{
    public int EmailCampaignId { get; set; }
    public int CampaignId { get; set; } // Foreign key to Campaign
    public Campaign? Campaign { get; set; } // Navigation property
    public int EmailTemplateId { get; set; } // Foreign key to EmailTemplate
    public EmailTemplate? EmailTemplate { get; set; } // Navigation property
    public int? SegmentId { get; set; } // Foreign key to Segment, optional segment
    public Segment? Segment { get; set; } // Navigation property
}