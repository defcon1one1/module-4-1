namespace module_4_1.DAL
{

    public static class DataSeeder

    {
        public static void Seed(UniversityDbContext context)
        {
            var courses = new List<Course>
        {
            new Course { Name = "Mathematics" },
            new Course { Name = "History" },
            new Course { Name = "Chemistry" }
        };

            context.Courses.AddRange(courses);

            var modules = new List<Module>
        {
            new Module { Name = "Algebra", CourseId = 1 },
            new Module { Name = "Geometry", CourseId = 1 },
            new Module { Name = "Calculus", CourseId = 1 },
            new Module { Name = "World War I", CourseId = 2 },
            new Module { Name = "World War II", CourseId = 2 },
            new Module { Name = "American Revolution", CourseId = 2 },
            new Module { Name = "Chemical Reactions", CourseId = 3 },
            new Module { Name = "Organic Chemistry", CourseId = 3 }
        };

            context.Modules.AddRange(modules);

            var students = new List<Student>
        {
            new Student { Name = "John Doe" },
            new Student { Name = "Jane Smith" },
            new Student { Name = "Mark Johnson" }
        };

            context.Students.AddRange(students);

            var courseEnrollments = new List<CourseEnrollment>
        {
            new CourseEnrollment { CourseId = 1, StudentId = 1 },
            new CourseEnrollment { CourseId = 1, StudentId = 2 },
            new CourseEnrollment { CourseId = 2, StudentId = 2 },
            new CourseEnrollment { CourseId = 3, StudentId = 3 }
        };

            context.CourseEnrollments.AddRange(courseEnrollments);

            var moduleGrades = new List<ModuleGrade>
        {
            new ModuleGrade { ModuleId = 1, CourseEnrollmentId = 1, Grade = 80 },
            new ModuleGrade { ModuleId = 2, CourseEnrollmentId = 1, Grade = 90 },
            new ModuleGrade { ModuleId = 3, CourseEnrollmentId = 1, Grade = 85 },
            new ModuleGrade { ModuleId = 4, CourseEnrollmentId = 2, Grade = 75 },
            new ModuleGrade { ModuleId = 5, CourseEnrollmentId = 2, Grade = 95 },
            new ModuleGrade { ModuleId = 6, CourseEnrollmentId = 2, Grade = 80 },
            new ModuleGrade { ModuleId = 7, CourseEnrollmentId = 3, Grade = 90 },
            new ModuleGrade { ModuleId = 8, CourseEnrollmentId = 3, Grade = 85 }
        };

            context.ModuleGrades.AddRange(moduleGrades);

            context.SaveChanges();
        }
    }
}