namespace SAX.Application.Features.Marketing.DTOs.Segment;

public class UpdateSegmentDto
{
    public Guid SegmentId { get; set; }
    public string? SegmentName { get; set; }
    public string? Criteria { get; set; }
}