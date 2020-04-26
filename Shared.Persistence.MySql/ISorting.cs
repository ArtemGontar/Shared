using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Shared.Persistence.MySql
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
