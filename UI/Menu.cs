using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using module_4_1.DAL;

namespace module_4_1.UI
{
    public class Menu
    {

        private readonly UniversityDbContext _context;

        private readonly Repository<Student> _studentRepository;
        private readonly Repository<Course> _courseRepository;
        private readonly Repository<CourseEnrollment> _enrollmentRepository;
        private readonly Repository<Module> _moduleRepository;
        private readonly Repository<ModuleGrade> _gradeRepository;

        public Menu(
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




        public void RunMenu()
        {


            Console.WriteLine("Welcome to Online University!");
            bool menuActive = true;
            while(menuActive)
            {
                Console.WriteLine();
                Console.WriteLine("Select one of the options below");
                Console.WriteLine("1. Get a list of active courses");
                Console.WriteLine("2. Get a full list of students");
                Console.WriteLine("3. Get a list of courses taken by student");
                Console.WriteLine("4. Get a list of marks the particular student got for the given course");
                Console.WriteLine("5. Quit");
                int userInput = 0;
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
                switch (userInput) 
                {
                    case 1:
                        {
                            PrintListOfCourses();
                            break;
                        }
                    case 2:
                        {
                            PrintListOfStudents();
                            break;
                        }
                    case 3:
                        {
                            PrintListOfCoursesTakenByStudent();
                            break;
                        }
                    case 4:
                        {
                            PrintGradesForStudentsCourse();
                            break;
                        }
                    case 5: 
                        { 
                            menuActive = false; break; 
                        }
                    default: Console.WriteLine("You didn't select the correct option, please try again"); break;
                }



            }


        }



        private void PrintListOfCourses()
        {
            Console.WriteLine();
            Console.WriteLine("List of available courses:");
            var courses = _courseRepository.GetActiveCourses();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course ID: {course.Id} - {course.Name}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void PrintListOfStudents()
        {
            Console.WriteLine();
            Console.WriteLine("List of students:");
            var students = _studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.Id} - {student.Name}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void PrintListOfCoursesTakenByStudent()
        {
            Console.WriteLine();
            Console.WriteLine("Enter student id:");
            int studentId = 0;
            while (true)
            {
                try
                {
                    studentId = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Wrong input. Try again.");
                }
            }
            var student = _studentRepository.GetById(studentId);
            if (student == null)
            {
                Console.WriteLine($"Student of id {studentId} doesn't exist.");
                return;
            }

            var coursesTakenByStudent = _courseRepository.GetCoursesTakenByStudent(studentId);

            //check if the student is enrolled in any course
            if (!coursesTakenByStudent.Any())
            {
                Console.WriteLine($"Student {student.Name} is not enrolled in any course.");
                return;
            }

            var completedCourses = _courseRepository.GetCompletedCoursesTakenByStudent(studentId);

            Console.WriteLine($"Student {student.Name} is enrolled in the following courses:");
            foreach (var course in coursesTakenByStudent)
            {
                Console.WriteLine($"Course ID: {course.Id} - {course.Name}");
            }
            if (completedCourses.Any())
            {
                Console.WriteLine($"The following courses are finished by student {student.Name}");
                foreach (var course in completedCourses)
                {
                    Console.WriteLine($"Course ID: {course.Id} - {course.Name}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void PrintGradesForStudentsCourse()
        {

            Console.WriteLine();
            Console.WriteLine("Enter student id:");
            int studentId = 0;
            while (true)
            {
                try
                {
                    studentId = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Wrong input. Try again.");
                }
            }

            var student = _studentRepository.GetById(studentId);

            if (student == null)
            {
                Console.WriteLine($"ERROR: Student of id {studentId} doesn't exist.");
                Console.WriteLine();
                return;
            }

            //check if the student is enrolled in any course
            var coursesTakenByStudent = _courseRepository.GetCoursesTakenByStudent(studentId);
            if (!coursesTakenByStudent.Any())
            {
                Console.WriteLine($"Student {student.Name} is not enrolled in any course.");
                return;
            }


            Console.WriteLine($"Student {student.Name} is enrolled in the following courses:");
            foreach (var c in coursesTakenByStudent)
            {
                Console.WriteLine($"Course ID: {c.Id} - {c.Name}");
            }

            Console.WriteLine("Grades for which course would you like to view?");
            int courseId = 0;
            while (true)
            {
                try
                {
                    courseId = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Wrong input. Try again.");
                }
            }

            var course = _courseRepository.GetById(courseId);
            if (course == null)
            {
                Console.WriteLine($"ERROR: Course of id {courseId} doesn't exist.");
                Console.WriteLine();
                return;
            }

            var grades = _gradeRepository.GetGradesForStudentInCourse(studentId, courseId);

            if (!coursesTakenByStudent.Contains(course))
            {
                Console.WriteLine($"ERROR: Wrong course id - student not enrolled in this course.");
                return;
            }

            //check if student has any grades for this course
            if (!grades.Any())
            {
                Console.WriteLine($"Student {student.Name} doesn't have any grades in course {course.Name}");
                return;
            }

            Console.WriteLine($"Grades for course {course.Name}:");
            foreach (var grade in grades)
            {
                Console.WriteLine(grade.Grade);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
