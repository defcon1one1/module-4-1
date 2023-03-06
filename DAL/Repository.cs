namespace module_4_1.DAL
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class

    {
        private readonly UniversityDbContext _context;

        public Repository(UniversityDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}