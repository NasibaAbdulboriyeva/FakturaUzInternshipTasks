using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskDowloader.Application.DTOs
{
    public class DownloadProgress
    {
        public long DownloadItemId { get; set; } 
        public string FileName { get; set; } = default!;
        public double Percentage { get; set; } 
        public long BytesReceived { get; set; }
        public long? TotalBytes { get; set; } 
        public bool IsCompleted { get; set; }
        public bool IsFailed { get; set; }
    }
}
