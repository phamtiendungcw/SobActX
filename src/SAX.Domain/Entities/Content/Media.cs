namespace SAX.Domain.Entities.Content;

public class Media
{
    public int MediaId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string MediaType { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; }
}