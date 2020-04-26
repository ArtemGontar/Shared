using Microsoft.EntityFrameworkCore;
using Shared.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Persistence.MySql
{
    public class SQLRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SQLRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<long> CountAsync() => await _dbSet.CountAsync();

        public async Task<long> CountAsync(ISqlSpecification<T> specification)
            => await _dbSet.CountAsync(specification.Predicate);

        public async Task<bool> AnyAsync() => await _dbSet.AnyAsync();

        public async Task<bool> AnyAsync(ISqlSpecification<T> specification)
            => await _dbSet.AnyAsync(specification.Predicate);

        public async Task<T> GetAsync(ISqlSpecification<T> specification)
        {
            var query = _dbSet.Include(specification.Includes);

            return specification.AsNoTracking ?
                await query.AsNoTracking().FirstOrDefaultAsync(specification.Predicate) :
                await query.FirstOrDefaultAsync(specification.Predicate);
        }

        public async Task<List<T>> GetAllAsync(ISqlSpecification<T> specification)
        {
            var query = _dbSet.Include(specification.Includes);

            if (specification.Predicate != null)
            {
                query = query.Where(specification.Predicate);
            }

            return specification.AsNoTracking ?
                await query.AsNoTracking().ToListAsync() :
                await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISqlSpecification<T> specification, ISorting<T> sorting)
        {
            var query = _dbSet.Include(specification.Includes);

            if (specification.Predicate != null)
            {
                query = query.Where(specification.Predicate);
            }

            query = sorting.SortingType == SortingType.Ascending ?
                query.OrderBy(sorting.Selector) :
                query.OrderByDescending(sorting.Selector);

            return specification.AsNoTracking ?
                await query.AsNoTracking().ToListAsync() :
                await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISqlSpecification<T> specification, ISorting<T> sorting,
            Limiting limit)
        {
            var query = _dbSet.Include(specification.Includes);

            if (specification.Predicate != null)
            {
                query = query.Where(specification.Predicate);
            }

            query = sorting.SortingType == SortingType.Ascending ?
                query.OrderBy(sorting.Selector) :
                query.OrderByDescending(sorting.Selector);

            return specification.AsNoTracking ?
                await query.Take(limit.CountOfRecords).AsNoTracking().ToListAsync() :
                await query.Take(limit.CountOfRecords).ToListAsync();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(ISqlSpecification<T> specification)
        {
            var entitiesToDelete = await GetAllAsync(specification);
            _dbSet.RemoveRange(entitiesToDelete);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
