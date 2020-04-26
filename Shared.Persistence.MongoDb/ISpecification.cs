using System;
using System.Linq.Expressions;

namespace Shared.Persistence.MongoDb
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
    }
}
