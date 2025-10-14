using CarCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCrud.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                   .IsUnique();
            builder.Property(u => u.UserName)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.HasIndex(u => u.UserName)
                   .IsUnique();
            builder.Property(u => u.PasswordHash)
                   .IsRequired();
            builder.HasMany(ur => ur.Cars)
                    .WithOne(u => u.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            builder.Property(u => u.Role)
        .IsRequired()
        .HasConversion<int>();

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
