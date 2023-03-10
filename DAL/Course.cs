namespace module_4_1.DAL
{

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Module> Modules { get; set; }

        public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    }
}