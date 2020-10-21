using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Infrastructure.DataAccess.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(b => b.AreaId);
            builder.Property(b => b.Name);
            builder.HasMany(b => b.Subareas)
                .WithOne(b => b.Area!)
                .HasForeignKey(b => b.AreaId);
        }
    }
}
