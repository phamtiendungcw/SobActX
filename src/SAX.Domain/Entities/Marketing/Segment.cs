namespace SAX.Domain.Entities.Marketing;

public class Segment : BaseEntity
{
    public string SegmentName { get; set; } = string.Empty;
    public string? Criteria { get; set; } // Description of segment criteria
    public ICollection<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>();
}