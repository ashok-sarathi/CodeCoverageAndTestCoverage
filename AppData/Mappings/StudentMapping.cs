using AppData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Age).IsRequired();

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Department).WithMany(p => p.Students).HasForeignKey(p => p.DepartmentId);
        }
    }
}
