using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSchoolLab.Entities;
using Microsoft.EntityFrameworkCore;
namespace EFSchoolLab
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer();
    }
}
