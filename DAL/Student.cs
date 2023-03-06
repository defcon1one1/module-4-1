using module_4_1.DAL;
namespace module_4_1.DAL
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }
    }
}