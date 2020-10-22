using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Infrastructure.DataAccess.Configuration
{
    public class SubareaConfiguration : IEntityTypeConfiguration<Subarea>
    {
        public void Configure(EntityTypeBuilder<Subarea> builder)
        {
            builder.Property(b => b.SubareaId)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.Name);
            builder.HasMany(x => x.Employees)
                .WithOne(b => b.Subarea)
                .HasForeignKey(b => b.SubareaId);
        }
    }
}
