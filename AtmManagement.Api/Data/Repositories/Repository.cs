using Microsoft.EntityFrameworkCore;

namespace AtmManagement.Api.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AtmDbContext _context;
        protected readonly DbSet<T> _dbSet;

        // Repository sınıfının constructor metodu.
        public Repository(AtmDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task AddAsync(T entity)
        {
            
           await _dbSet.AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
