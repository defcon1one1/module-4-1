namespace module_4_1.DAL
{

    public class CourseEnrollment
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<ModuleGrade> ModuleGrades { get; set; }
    }
}