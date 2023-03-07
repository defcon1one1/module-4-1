namespace module_4_1.DAL
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        IEnumerable<Course> GetActiveCourses();

        IEnumerable<Student> GetAllStudents();
        IEnumerable<Course> GetCoursesTakenByStudent(int studentId);
        IEnumerable<ModuleGrade> GetGradesForStudentInCourse(int studentId, int courseId);

        public void AddGrade(int studentId, int moduleId, int grade);
        void MarkCourseAsComplete(int studentId, int courseId);

    }
}