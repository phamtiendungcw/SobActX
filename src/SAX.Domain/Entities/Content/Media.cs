namespace SAX.Domain.Entities.Content;

public class Media : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public MediaType MediaType { get; set; } // Enum MediaType { Image, Video, Document }
    public DateTime UploadDate { get; set; }
}