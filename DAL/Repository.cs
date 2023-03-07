using Microsoft.EntityFrameworkCore;

namespace module_4_1.DAL
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UniversityDbContext _context;

        public Repository(UniversityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetActiveCourses()
        {
            return _context.Courses.ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public IEnumerable<Course> GetCoursesTakenByStudent(int studentId)
        {
            return _context.CourseEnrollments
                .Where(e => e.StudentId == studentId && e.IsCompleted == false)
                .Select(e => e.Course)
                .ToList();
        }

        public IEnumerable<Course> GetCompletedCoursesTakenByStudent(int studentId)
        {
            return _context.CourseEnrollments
                .Where(e => e.StudentId == studentId && e.IsCompleted == true)
                .Select(e => e.Course)
                .ToList();
        }

        public IEnumerable<ModuleGrade> GetGradesForStudentInCourse(int studentId, int courseId)
        {
            return _context.ModuleGrades
                .Where(g => g.CourseEnrollment.StudentId == studentId && g.Module.CourseId == courseId)
                .ToList();
        }

    }

}