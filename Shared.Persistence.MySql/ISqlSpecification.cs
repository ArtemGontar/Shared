using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Persistence.MySql
{
    public interface ISqlSpecification<T> : ISpecification<T>
    {
        bool AsNoTracking { get; }

        Func<IQueryable<T>, IIncludableQueryable<T, object>>[] Includes { get; }
    }

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
    }
}
