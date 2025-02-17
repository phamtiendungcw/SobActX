namespace SAX.Domain.Entities.Content;

public class Media : BaseEntity
{
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}