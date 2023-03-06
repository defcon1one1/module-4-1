namespace module_4_1.DAL
{


    public class ModuleGrade
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int CourseEnrollmentId { get; set; }
        public CourseEnrollment CourseEnrollment { get; set; }
    }
}