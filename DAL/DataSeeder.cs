using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_4_1.DAL
{
    internal class DataSeeder
    {
        private readonly Repository<Student> _studentRepository;
        private readonly Repository<Course> _courseRepository;
        private readonly Repository<CourseEnrollment> _enrollmentRepository;
        private readonly Repository<Module> _moduleRepository;
        private readonly Repository<ModuleGrade> _gradeRepository;

        public DataSeeder(
            Repository<Student> studentRepository,
            Repository<Course> courseRepository,
            Repository<CourseEnrollment> enrollmentRepository,
            Repository<Module> moduleRepository,
            Repository<ModuleGrade> gradeRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _moduleRepository = moduleRepository;
            _gradeRepository = gradeRepository;
        }


        public void Seed()
        {
            // ---------------------students 
            var students = new List<Student>
            {
                new Student { Name = "John Smith" },
                new Student { Name = "Anna Doe" },
                new Student { Name = "Bob Johnson" },
                new Student { Name = "Frank Underwood" },
                new Student { Name = "Matthew Harris" },
                new Student { Name = "Gregory Taylor" }

            };

            foreach (var student in students)
            {
                _studentRepository.Add(student);
            }

            // ---------------------courses 
            var courses = new List<Course>
            {
                new Course { Name = "Math" },
                new Course { Name = "History" },
                new Course { Name = "Biology"},
                new Course { Name = "Chemistry" }
            };

            foreach (var course in courses)
            {
                _courseRepository.Add(course);
            }
            _courseRepository.SaveChanges();

            // ---------------------modules


            var modules = new List<Module>
            {
                new Module { Name = "Algebra", CourseId = 1 },
                new Module { Name = "Calculus", CourseId = 1 },
                new Module { Name = "Statistics", CourseId = 1 },

                new Module { Name = "Medieval history", CourseId = 2 },
                new Module { Name = "Modern history", CourseId = 2 },
                new Module { Name = "Ancient history", CourseId = 2},

                new Module { Name = "Science of evolution", CourseId = 3 },
                new Module { Name = "History of biology", CourseId = 3 },
                new Module { Name = "Genetics", CourseId = 3},

                new Module { Name = "Basics of chemistry", CourseId = 4 },
                new Module { Name = "Organic chemistry", CourseId = 4 },
                new Module { Name = "Practical chemistry", CourseId = 4}


            };

            foreach (var module in modules)
            {
                _moduleRepository.Add(module);
            }
            _moduleRepository.SaveChanges();


            // ---------------------enrollments
            var enrollments = new List<CourseEnrollment>
            {
                new CourseEnrollment {IsCompleted = false, StudentId = 1, CourseId = 1 },
                new CourseEnrollment {IsCompleted = true, StudentId = 1, CourseId = 2 },

                new CourseEnrollment {IsCompleted = false, StudentId = 2, CourseId = 2 },
                new CourseEnrollment {IsCompleted = false, StudentId = 2, CourseId = 3 },

                new CourseEnrollment {IsCompleted = false, StudentId = 3, CourseId = 4 }
            };

            foreach (var enrollment in enrollments)
            {
                _enrollmentRepository.Add(enrollment);
            }

            _enrollmentRepository.SaveChanges();

            // ---------------------grades
            var grades = new List<ModuleGrade>
            {
                new ModuleGrade { Grade = 3, ModuleId = 1, CourseEnrollmentId = 1 },
                new ModuleGrade { Grade = 5, ModuleId = 2, CourseEnrollmentId = 1 },

                new ModuleGrade { Grade = 3, ModuleId = 4, CourseEnrollmentId = 1 },
                new ModuleGrade { Grade = 5, ModuleId = 5, CourseEnrollmentId = 1 },
                new ModuleGrade { Grade = 4, ModuleId = 6, CourseEnrollmentId = 1 },

                new ModuleGrade { Grade = 3, ModuleId = 4, CourseEnrollmentId = 2 },
                new ModuleGrade { Grade = 5, ModuleId = 5, CourseEnrollmentId = 2 },

                new ModuleGrade { Grade = 3, ModuleId = 10, CourseEnrollmentId = 3 }


            };

            foreach (var grade in grades)
            {
                _gradeRepository.Add(grade);
            }

            _gradeRepository.SaveChanges();


        }



    }
}
