using MultiTaskDowloader.Application.DTOs;
using MultiTaskDownloader.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskDowloader.Application.Services
{
    public interface IDownloadService
    {
        Task AddDownloadAsync(string url, string filePath);

        Task StartPendingDownloadsAsync();

        Task RetryFailedDownloadsAsync();

        Task<List<DownloadItem>> GetAllDownloadsAsync();

        Task<List<DownloadItem>> GetDownloadsByStatusAsync(DownloadStatus status);

        Task<DownloadItem?> GetDownloadByIdAsync(long id);

        Task CancelDownloadAsync(long id);

        Task<long> GetTotalDownloadedBytesAsync();
        Task<DownloadProgress?> GetDownloadProgressAsync(long id);
        Task DeleteDownloadAsync(long id);
    }
}
