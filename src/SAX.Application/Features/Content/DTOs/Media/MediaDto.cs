namespace SAX.Application.Features.Content.DTOs.Media;

public class MediaDto
{
    public Guid MediaId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}