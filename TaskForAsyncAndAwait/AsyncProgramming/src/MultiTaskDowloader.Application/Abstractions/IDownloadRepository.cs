using MultiTaskDownloader.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskDowloader.Application.Abstractions
{
    public interface IDownloadRepository
    {
        Task InsertAsync(DownloadItem item);
        Task UpdateAsync(DownloadItem item);
        Task RemoveAsync(DownloadItem item);
        Task<List<DownloadItem>> SelectAllAsync();
        Task<List<DownloadItem>> SelectByStatusAsync(DownloadStatus status);
        Task<DownloadItem?> SelectByIdAsync(long id);
    }
}
