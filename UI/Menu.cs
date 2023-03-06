using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using module_4_1.DAL;

namespace module_4_1.UI
{
    public class Menu
    {

        private readonly UniversityDbContext _context;

        public Menu(UniversityDbContext context)
        {
            _context = context;
        }
        public void RunMenu()
        {


            Repository<Student> studentRepository = new Repository<Student>(_context);
            Repository<Course> courseRepository = new Repository<Course>(_context);
            Repository<CourseEnrollment> enrollmentRepository = new Repository<CourseEnrollment>(_context);
            Repository<ModuleGrade> gradeRepository = new Repository<ModuleGrade>(_context);

            Console.WriteLine("Welcome to Online University!");
            bool menuActive = true;
            while(menuActive)
            {
                Console.WriteLine("Select one of the options below");
                Console.WriteLine("1. Get a list of active courses");
                Console.WriteLine("2. Get a full list of students");
                Console.WriteLine("3. Get a list of courses taken by student");
                Console.WriteLine("4. Get a list of marks the particular student got for the given course.");
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
                    case 1: courseRepository.GetActiveCourses(); break;
                    case 2: studentRepository.GetAllStudents(); break;
                    //case 3: enrollmentRepository.GetCoursesTakenByStudent(); break;
                    //case 4: gradeRepository.GetGradesForStudentInCourse(); break;
                    case 5: menuActive = false; break;
                    default: Console.WriteLine("You didn't select the correct option, please try again"); break;
                }
            }
        }
    }
}
