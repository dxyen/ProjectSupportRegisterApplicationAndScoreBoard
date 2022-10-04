using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.ToTable("AppUsers");
            entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(true);

            entity.Property(e => e.Avatar)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.Birthday).HasColumnType("date");

            entity.Property(e => e.FullName)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
