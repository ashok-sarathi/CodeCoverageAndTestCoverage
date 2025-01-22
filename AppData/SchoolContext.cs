using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AppData.Entities;

namespace AppData
{
    public class SchoolContext(DbContextOptions<SchoolContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }   
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SchoolContext)) ?? throw new NullReferenceException($"{nameof(Assembly)} is null"));
        }
    }
}
