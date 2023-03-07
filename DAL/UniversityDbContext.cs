using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace module_4_1.DAL
{
    public class UniversityDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<ModuleGrade> ModuleGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEnrollment>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.HasMany(ce => ce.ModuleGrades)
                    .WithOne(mg => mg.CourseEnrollment)
                    .HasForeignKey(mg => mg.CourseEnrollmentId);
            });

            modelBuilder.Entity<Course>(eb => {

                eb.HasKey(e => e.Id);

                eb.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                eb.HasMany(c => c.Modules)
                    .WithOne(m => m.Course)
                    .HasForeignKey(m => m.CourseId);
            });

            modelBuilder.Entity<Student>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                eb.HasMany(s => s.CourseEnrollments)
                    .WithOne(ce => ce.Student)
                    .HasForeignKey(ce => ce.StudentId);
            });

            modelBuilder.Entity<ModuleGrade>(eb =>
            {
                eb.HasKey(e => e.Id);

                eb.ToTable(e => e.HasCheckConstraint("CK_ModuleGrade_Grade", "[Grade] BETWEEN 3 AND 5"));

                eb.HasOne(mg => mg.Module)
                    .WithMany()
                    .HasForeignKey(mg => mg.ModuleId)
                    .OnDelete(DeleteBehavior.NoAction);

                eb.HasOne(mg => mg.CourseEnrollment)
                    .WithMany(ce => ce.ModuleGrades)
                    .HasForeignKey(mg => mg.CourseEnrollmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=OnlineUniversityDb;Integrated Security=True");
        }
    }
}
