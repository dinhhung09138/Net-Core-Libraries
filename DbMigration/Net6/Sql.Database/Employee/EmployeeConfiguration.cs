using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sql.Database
{
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee), "dbo");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.Name).HasMaxLength(100).IsRequired();

            builder.Property(m => m.Phone).HasMaxLength(15).HasColumnType("varchar").IsRequired();

            builder.Property(m => m.Age).IsRequired();

            builder.Property(m => m.Email).HasMaxLength(50).HasColumnType("varchar");
        }
    }
}
