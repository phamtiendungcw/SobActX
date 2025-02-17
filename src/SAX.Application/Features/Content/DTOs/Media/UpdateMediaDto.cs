namespace SAX.Application.Features.Content.DTOs.Media;

public class UpdateMediaDto
{
    public Guid MediaId { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }

    public string? MediaType { get; set; }
    // UploadDate không nên được cập nhật
}