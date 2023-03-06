using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_4_1.UI
{
    public class Menu
    {
        public void RunMenu()
        {
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
                    case 1: GetListOfActiveCourses(); break;
                    case 2: GetFullListOfStudents(); break;
                    case 3: GetListOfStudentEnrollments(); break;
                    case 4: GetListOfStudentMarks(); break;
                    case 5: menuActive = false; break;
                    default: Console.WriteLine("You didn't select the correct option, please try again"); break;
                }
            }
        }
    }
}
