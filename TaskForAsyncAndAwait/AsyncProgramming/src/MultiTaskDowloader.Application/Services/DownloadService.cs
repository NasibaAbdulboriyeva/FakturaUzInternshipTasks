using MultiTaskDowloader.Application.Abstractions;
using MultiTaskDowloader.Application.DTOs;
using MultiTaskDownloader.Domain.Entities;
using System.Collections.Concurrent;

namespace MultiTaskDowloader.Application.Services
{
    public class DownloadService : IDownloadService
    {
        private readonly IDownloadRepository _repository;

        private readonly ConcurrentDictionary<long, DownloadProgress> _progressTracker = new();

        public DownloadService(IDownloadRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDownloadAsync(string url, string filePath)
        {
            var downloadItem = new DownloadItem
            {
                Url = url,
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                Status = DownloadStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.InsertAsync(downloadItem);
        }

        // Start all pending downloads concurrently
        public async Task StartPendingDownloadsAsync()
        {
            var pendingDownloads = await _repository.SelectByStatusAsync(DownloadStatus.Pending);
            var downloadTasks = pendingDownloads.Select(item => DownloadFileAsync(item));
            await Task.WhenAll(downloadTasks);
        }

        // Simulated file download with progress
        private async Task DownloadFileAsync(DownloadItem item)
        {
            item.Status = DownloadStatus.Downloading;
            await _repository.UpdateAsync(item);

            var totalBytes = 1000; // simulate file size
            long bytesReceived = 0;

            while (bytesReceived < totalBytes)
            {
                await Task.Delay(50); // simulate network delay
                bytesReceived += 100; // increment progress

                // Update in-memory progress
                var progress = new DownloadProgress
                {
                    DownloadItemId = item.DownloadItemId,
                    FileName = item.FileName,
                    BytesReceived = bytesReceived,
                    TotalBytes = totalBytes,
                    Percentage = (double)bytesReceived / totalBytes * 100,
                    IsCompleted = false,
                    IsFailed = false
                };

                _progressTracker[item.DownloadItemId] = progress;
            }

            // Download complete
            item.Status = DownloadStatus.Completed;
            item.CompletedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(item);

            // Final progress
            _progressTracker[item.DownloadItemId] = new DownloadProgress
            {
                DownloadItemId = item.DownloadItemId,
                FileName = item.FileName,
                BytesReceived = totalBytes,
                TotalBytes = totalBytes,
                Percentage = 100,
                IsCompleted = true,
                IsFailed = false
            };
        }

        // Get progress by download id
        public Task<DownloadProgress?> GetDownloadProgressAsync(long id)
        {
            _progressTracker.TryGetValue(id, out var progress);
            return Task.FromResult(progress);
        }

        public async Task RetryFailedDownloadsAsync()
        {
            var failedDownloads = await _repository.SelectByStatusAsync(DownloadStatus.Failed);
            var tasks = failedDownloads.Select(item => DownloadFileAsync(item));
            await Task.WhenAll(tasks);
        }

        public async Task<List<DownloadItem>> GetAllDownloadsAsync()
        {
            return await _repository.SelectAllAsync();
        }

        public async Task<DownloadItem?> GetDownloadByIdAsync(long id)
        {
            return await _repository.SelectByIdAsync(id);
        }

        public async Task<List<DownloadItem>> GetDownloadsByStatusAsync(DownloadStatus status)
        {
            return await _repository.SelectByStatusAsync(status);
        }

        public Task CancelDownloadAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDownloadAsync(long id)
        {
            var item = await _repository.SelectByIdAsync(id);
            if (item != null)
            {
                await _repository.RemoveAsync(item);
                _progressTracker.TryRemove(id, out _);
            }
        }

        public async Task<long> GetTotalDownloadedBytesAsync()
        {
            var allDownloads = await _repository.SelectAllAsync();
            return allDownloads.Where(d => d.Status == DownloadStatus.Completed)
                               .Sum(d => d.Size ?? 0);
        }
    }
}
