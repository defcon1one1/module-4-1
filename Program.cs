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
            var courseEnRepo = new Repository<CourseEnrollment>(context);
            var moduleRepo = new Repository<Module>(context);
            var moduleGradeRepo = new Repository<ModuleGrade>(context);

            var menu = new Menu(studentRepo, courseRepo, courseEnRepo, moduleRepo, moduleGradeRepo);
            menu.RunMenu();


        }
    }
}