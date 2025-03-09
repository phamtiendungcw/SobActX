using SAX.Domain;

namespace SAX.Application.Features.Content.DTOs.Media;

public class MediaDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public MediaType MediaType { get; set; }
    public DateTime UploadDate { get; set; }
}