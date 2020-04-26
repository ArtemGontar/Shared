using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;

namespace Shared.Persistence.MySql
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Includes an array of navigation properties for the specified query.
        /// </summary>
        /// <typeparam name="T">The type of the entity</typeparam>
        /// <param name="query">The query to include navigation properties for that</param>
        /// <param name="includes">The array of navigation properties to include</param>
        /// <returns></returns>
        public static IQueryable<T> Include<T>(this IQueryable<T> query,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
            where T : class
        {
            if (includes == null)
            {
                return query;
            }

            foreach (var include in includes)
            {
                query = include(query);
            }

            return query;
        }
    }
}
