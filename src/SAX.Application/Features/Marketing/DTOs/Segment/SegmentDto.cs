namespace SAX.Application.Features.Marketing.DTOs.Segment;

public class SegmentDto
{
    public Guid SegmentId { get; set; }
    public string SegmentName { get; set; } = string.Empty;
    public string? Criteria { get; set; }
}