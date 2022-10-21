using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {

        public void Configure(EntityTypeBuilder<AppRole> entity)
        {
            entity.ToTable("AppRoles");
            entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(true);
        }
    }
}
