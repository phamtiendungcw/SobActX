namespace SAX.Application.Features.Marketing.DTOs.Segment;

public class SegmentDto
{
    public Guid Id { get; set; }
    public string SegmentName { get; set; } = string.Empty;
    public string? Criteria { get; set; }
}