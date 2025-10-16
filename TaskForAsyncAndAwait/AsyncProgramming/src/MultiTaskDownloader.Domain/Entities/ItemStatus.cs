using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskDownloader.Domain.Entities
{
    public enum DownloadStatus
    {
        Pending,
        Downloading,
        Completed,
        Failed
    }
}
