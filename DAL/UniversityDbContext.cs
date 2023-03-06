using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace module_4_1.DAL
{

    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<ModuleGrade> ModuleGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEnrollment>()
                .HasMany(ce => ce.ModuleGrades)
                .WithOne(mg => mg.CourseEnrollment)
                .HasForeignKey(mg => mg.CourseEnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Modules)
                .WithOne(m => m.Course)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.CourseEnrollments)
                .WithOne(ce => ce.Student)
                .HasForeignKey(ce => ce.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseEnrollments)
                .WithOne(ce => ce.Course)
                .HasForeignKey(ce => ce.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}