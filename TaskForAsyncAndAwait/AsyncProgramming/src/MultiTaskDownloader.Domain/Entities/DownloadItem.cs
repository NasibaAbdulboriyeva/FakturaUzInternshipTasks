namespace MultiTaskDownloader.Domain.Entities;

public class DownloadItem
{
    public long DownloadItemId { get; set; }                       
    public string Url { get; set; } = default!;        
    public string FileName { get; set; } = default!;   
    public string FilePath { get; set; } = default!;  
    public DownloadStatus Status { get; set; } = DownloadStatus.Pending;
    public long? Size { get; set; }    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    public DateTime? CompletedAt { get; set; }     
    public string? ErrorMessage { get; set; }      
}