namespace SAX.Domain.Entities.Marketing;

public class Campaign : BaseEntity
{
    public string CampaignName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } // Campaign might not have an end date
    public string? TargetAudience { get; set; }
    public decimal? Budget { get; set; } // Budget might be optional or not set initially
    public ICollection<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>();
}