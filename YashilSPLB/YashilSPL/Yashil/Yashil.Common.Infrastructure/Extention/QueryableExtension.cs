using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Yashil.Common.Infrastructure.Extention
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Order<T>(this IQueryable<T> queryable, string property, bool ascending)
        {
            if (queryable == default || string.IsNullOrEmpty(property))
            {
                return queryable;
            }

            var properties = property.Split('.');

            var propertyType = typeof(T);

            propertyType = properties.Aggregate(propertyType, (propertyTypeCurrent, propertyName) => propertyTypeCurrent.GetProperty(propertyName)?.PropertyType);

            if (propertyType == typeof(sbyte))
            {
                return queryable.Order<T, sbyte>(properties, ascending);
            }

            if (propertyType == typeof(short))
            {
                return queryable.Order<T, short>(properties, ascending);
            }

            if (propertyType == typeof(int))
            {
                return queryable.Order<T, int>(properties, ascending);
            }

            if (propertyType == typeof(long))
            {
                return queryable.Order<T, long>(properties, ascending);
            }

            if (propertyType == typeof(byte))
            {
                return queryable.Order<T, byte>(properties, ascending);
            }

            if (propertyType == typeof(ushort))
            {
                return queryable.Order<T, ushort>(properties, ascending);
            }

            if (propertyType == typeof(uint))
            {
                return queryable.Order<T, uint>(properties, ascending);
            }

            if (propertyType == typeof(ulong))
            {
                return queryable.Order<T, ulong>(properties, ascending);
            }

            if (propertyType == typeof(char))
            {
                return queryable.Order<T, char>(properties, ascending);
            }

            if (propertyType == typeof(float))
            {
                return queryable.Order<T, float>(properties, ascending);
            }

            if (propertyType == typeof(double))
            {
                return queryable.Order<T, double>(properties, ascending);
            }

            if (propertyType == typeof(decimal))
            {
                return queryable.Order<T, decimal>(properties, ascending);
            }

            if (propertyType == typeof(bool))
            {
                return queryable.Order<T, bool>(properties, ascending);
            }

            if (propertyType == typeof(string))
            {
                return queryable.Order<T, string>(properties, ascending);
            }

            return queryable.Order<T, object>(properties, ascending);
        }

        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, int size)
        {
            if (queryable == default || !queryable.Any() || index == 0 || size == 0)
            {
                return new List<T>().AsQueryable();
            }

            return queryable.Skip((index - 1) * size).Take(size);
        }

        private static IQueryable<T> Order<T, TKey>(this IQueryable<T> queryable, IEnumerable<string> properties, bool ascending)
        {
            var parameters = Expression.Parameter(typeof(T));

            var body = properties.Aggregate<string, Expression>(parameters, Expression.Property);

            var expression = Expression.Lambda<Func<T, TKey>>(body, parameters).Compile();

            return ascending ? queryable.AsEnumerable().OrderBy(expression).AsQueryable() : queryable.AsEnumerable().OrderByDescending(expression).AsQueryable();
        }
    }
}
