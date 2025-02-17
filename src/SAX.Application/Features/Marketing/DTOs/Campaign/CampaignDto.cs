namespace SAX.Application.Features.Marketing.DTOs.Campaign;

public class CampaignDto
{
    public Guid CampaignId { get; set; }
    public string CampaignName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? TargetAudience { get; set; }
    public decimal? Budget { get; set; }
}