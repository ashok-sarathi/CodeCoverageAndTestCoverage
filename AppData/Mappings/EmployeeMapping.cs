using AppData.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace AppData.Mappings
{
    [ExcludeFromCodeCoverage]
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Age).IsRequired();

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Department).WithMany(p => p.Employees).HasForeignKey(p => p.DepartmentId);
        }
    }
}
