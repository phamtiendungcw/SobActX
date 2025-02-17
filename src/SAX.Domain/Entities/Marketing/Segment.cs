namespace SAX.Domain.Entities.Marketing;

public class Segment
{
    public int SegmentId { get; set; }
    public string SegmentName { get; set; } = string.Empty;
    public string? Criteria { get; set; } // Description of segment criteria
    public ICollection<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>(); // Navigation property
}