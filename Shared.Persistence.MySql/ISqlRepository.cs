using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Persistence.MySql
{
    public interface ISqlRepository<T>
    {
        Task<long> CountAsync();
        Task<long> CountAsync(ISqlSpecification<T> specification);

        Task<bool> AnyAsync();
        Task<bool> AnyAsync(ISqlSpecification<T> specification);

        Task<T> GetAsync(ISqlSpecification<T> specification);
        Task<List<T>> GetAllAsync(ISqlSpecification<T> specification);
        Task<List<T>> GetAllAsync(ISqlSpecification<T> specification, ISorting<T> sorting);

        Task<List<T>> GetAllAsync(ISqlSpecification<T> specification, ISorting<T> sorting,
            Limiting limit);

        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(ISqlSpecification<T> specification);
    }
}
