using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MultiTaskDownloader.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskDownloader.Infrastructure.Persistence.Configurations
{

    public class DownloadItemConfiguration : IEntityTypeConfiguration<DownloadItem>
    {
        public void Configure(EntityTypeBuilder<DownloadItem> builder)
        {
            builder.ToTable("DownloadItems");

            builder.HasKey(x => x.DownloadItemId);

            builder.Property(x => x.Url)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.FileName)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.FilePath)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(x => x.Size);

            builder.Property(x => x.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.CompletedAt);

            builder.Property(x => x.ErrorMessage)
                   .HasMaxLength(1000);
        }
    }
}

