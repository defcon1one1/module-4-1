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
                .Where(e => e.StudentId == studentId)
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

        //public IEnumerable<ModuleGrade> GetGradesForStudentInCourse(int studentId, int courseId)
        //{
        //    var courseModules = _context.Modules.Where(m => m.CourseId == courseId).ToList();

        //    var grades = new List<ModuleGrade>();
        //    foreach (var module in courseModules)
        //    {
        //        var grade = _context.ModuleGrades
        //            .FirstOrDefault(g => g.CourseEnrollment.StudentId == studentId && g.ModuleId == module.Id);


        //        if (grade != null)
        //        {
        //            grades.Add(grade);
        //        }
        //    }

        //    return grades;
        //}

        public IEnumerable<ModuleGrade> GetGradesForStudentInCourse(int studentId, int courseId)
        {
            var courseEnrollmentIds = _context.CourseEnrollments
                .Where(e => e.StudentId == studentId && e.CourseId == courseId)
                .Select(e => e.Id)
                .ToList();

            var moduleGrades = _context.ModuleGrades
                .Include(g => g.Module)
                .Include(g => g.CourseEnrollment)
                .Where(g => courseEnrollmentIds.Contains(g.CourseEnrollmentId))
                .ToList();

            return moduleGrades;
        }






        public void AddGrade(int studentId, int moduleId, int grade)
        {
            var courseEnrollment = _context.CourseEnrollments.FirstOrDefault(e => e.StudentId == studentId && e.Course.Modules.Any(m => m.Id == moduleId));
            if (courseEnrollment != null)
            {
                var moduleGrade = _context.ModuleGrades.FirstOrDefault(g => g.CourseEnrollmentId == courseEnrollment.Id && g.Id == moduleId);
                if (moduleGrade != null)
                {
                    moduleGrade.Grade = grade;
                }
                else
                {
                    _context.ModuleGrades.Add(new ModuleGrade
                    {
                        CourseEnrollmentId = courseEnrollment.Id,
                        ModuleId = moduleId,
                        Grade = grade
                    });
                }
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("The student is not enrolled in the course to which the module belongs.");
            }
        }

        public void MarkCourseAsComplete(int studentId, int courseId)
        {
            // Get the course enrollment for the student and course
            var enrollment = _context.CourseEnrollments
                .SingleOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

            // Check if enrollment exists
            if (enrollment == null)
            {
                throw new ArgumentException("Course enrollment not found for the student and course");
            }

            // Check if the course is already completed
            if (enrollment.IsCompleted)
            {
                throw new ArgumentException("Course is already marked as completed");
            }

            // Get the modules for the course
            var modules = _context.Modules
                .Where(m => m.CourseId == courseId)
                .ToList();

            // Check if the student has received grades for all the modules
            if (modules.Any(m => _context.ModuleGrades
                .SingleOrDefault(g => g.CourseEnrollmentId == enrollment.Id && g.ModuleId == m.Id) == null))
            {
                throw new InvalidOperationException("Cannot mark course as completed because the student has not received grades for all the modules");
            }

            // Mark the course as completed
            enrollment.IsCompleted = true;
            _context.SaveChanges();
        }




    }

}