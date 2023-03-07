using module_4_1.DAL;
using module_4_1.UI;

namespace module_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new UniversityDbContext();

            var studentRepo = new Repository<Student>(context);
            var courseRepo = new Repository<Course>(context);
            var enrollmentsRepo = new Repository<CourseEnrollment>(context);
            var moduleRepo = new Repository<Module>(context);
            var gradesRepo = new Repository<ModuleGrade>(context);

            //var dataSeeder = new DataSeeder(studentRepo, courseRepo, enrollmentsRepo, moduleRepo, gradesRepo);
            //dataSeeder.Seed();

            var menu = new Menu(studentRepo, courseRepo, enrollmentsRepo, moduleRepo, gradesRepo);
            menu.RunMenu();




        }
    }
}