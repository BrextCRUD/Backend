using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            var property = typeof(T).GetProperty("Name");
            if (property != null && property.PropertyType == typeof(string))
            {
                return await _dbSet.AnyAsync(e => EF.Property<string>(e, "Name") == name);
            }
            throw new InvalidOperationException("La entidad no tiene una propiedad 'Name' de tipo string.");
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
