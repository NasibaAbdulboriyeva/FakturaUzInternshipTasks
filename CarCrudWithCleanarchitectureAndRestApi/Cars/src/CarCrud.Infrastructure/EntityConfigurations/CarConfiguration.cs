using CarCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCrud.Infrastructure.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.CarId);
            builder.Property(c => c.CarId);

            builder.Property(c => c.Brand)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Model)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.CarNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.Year)
                   .IsRequired();

            builder.Property(c => c.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.LastModifiedAt)
                   .IsRequired(false);

            builder.HasIndex(c => c.CarNumber)
                   .IsUnique();

        }
    }
}
