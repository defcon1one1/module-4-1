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
                new Student { Name = "Jane Doe" },
                new Student { Name = "Bob Johnson" }
            };

            foreach (var student in students)
            {
                _studentRepository.Add(student);
            }

            // ---------------------courses 
            var courses = new List<Course>
            {
                new Course { Name = "Math" },
                new Course { Name = "History" }
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
                new Module { Name = "Medieval history", CourseId = 2 },
                new Module { Name = "Modern history", CourseId = 2 },
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
                new CourseEnrollment {IsCompleted = false, StudentId = 2, CourseId = 2 }
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
                new ModuleGrade { Grade = 4, ModuleId = 3, CourseEnrollmentId = 2 },
            };

            foreach (var grade in grades)
            {
                _gradeRepository.Add(grade);
            }

            _gradeRepository.SaveChanges();


        }



    }
}
