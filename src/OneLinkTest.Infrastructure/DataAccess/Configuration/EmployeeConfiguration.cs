using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            if (builder is null)
            {
                throw new System.ArgumentNullException(nameof(builder));
            }

            builder.Property(b => b.EmployeeId)
                .HasConversion(
                    v => v.Id,
                    v => new EmployeeId(v))
                .IsRequired();

            builder.Property(b => b.Document);
            builder.Property(b => b.DocumentType);
            builder.Property(b => b.FirstName);
            builder.Property(b => b.LastName);

            builder.HasOne(b => b.Subarea!)
                .WithMany(b => b.Employees);
        }
    }
}
