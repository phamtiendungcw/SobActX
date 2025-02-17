namespace SAX.Application.Features.Marketing.DTOs.Segment;

public class CreateSegmentDto
{
    public string SegmentName { get; set; } = string.Empty;
    public string? Criteria { get; set; }
}