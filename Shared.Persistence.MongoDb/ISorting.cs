using System;
using System.Linq.Expressions;

namespace Shared.Persistence.MongoDb
{
    public interface ISorting<T>
    {
        Expression<Func<T, object>> Selector { get; }

        SortingType SortingType { get; }
    }

    public enum SortingType
    {
        Ascending = 1,
        Descending = 2
    }
}
