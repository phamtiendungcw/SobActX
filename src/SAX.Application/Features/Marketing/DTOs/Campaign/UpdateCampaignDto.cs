namespace SAX.Application.Features.Marketing.DTOs.Campaign;

public class UpdateCampaignDto
{
    public Guid CampaignId { get; set; }
    public string? CampaignName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? TargetAudience { get; set; }
    public decimal? Budget { get; set; }
}