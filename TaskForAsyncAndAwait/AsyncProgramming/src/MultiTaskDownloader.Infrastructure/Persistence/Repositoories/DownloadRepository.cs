using Microsoft.EntityFrameworkCore;
using MultiTaskDowloader.Application.Abstractions;
using MultiTaskDownloader.Domain.Entities;

namespace MultiTaskDownloader.Infrastructure.Persistence.Repositoories
{
    public class DownloadRepository : IDownloadRepository
    {
        private readonly AppDbContext _context;

        public DownloadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(DownloadItem item)
        {
            await _context.DownloadItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DownloadItem item)
        {
            _context.DownloadItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DownloadItem>> SelectAllAsync()
        {
            return await _context.DownloadItems
                                 .ToListAsync();
        }

        public async Task<DownloadItem?> SelectByIdAsync(long id)
        {
            return await _context.DownloadItems
                                 .FirstOrDefaultAsync(x => x.DownloadItemId == id);
        }

        public async Task<List<DownloadItem>> SelectByStatusAsync(DownloadStatus status)
        {
            return await _context.DownloadItems
                                 .Where(x => x.Status == status)
                                 .ToListAsync();
        }

        public async Task RemoveAsync(DownloadItem item)
        {
            _context.DownloadItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
