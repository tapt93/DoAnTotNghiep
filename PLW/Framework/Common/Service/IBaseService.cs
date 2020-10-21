using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Common.Service
{
    /// <summary>
    /// Base service class, support for query to database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="DC"></typeparam>
    public interface IBaseService<T, DC>
        where T : class, new()
        where DC : DbContext, new()
    {
        /// <summary>
        /// Adds a new record to the DB
        /// </summary>
        /// <param name="entity">Current Object</param>
        /// <param name="IdPropertyName">Name of the property containing identity Column or the ID returned by the DB</param>
        /// <returns><see cref="System.Object"/> </returns>
        object Add(T entity, string IdPropertyName);

        /// <summary>
        /// Adds a new record to the DB
        /// </summary>
        /// <param name="entity">Object entity to add</param>
        /// <returns>Object entity return</returns>
        T Add(T entity);

        /// <summary>
        /// Add list entity to the DB
        /// </summary>
        /// <param name="entities">A collection of entity</param>
        void Add(IList<T> entities);

        /// <summary>
        /// Get records from database
        /// </summary>
        /// <param name="query">where condition</param>
        /// <returns>records with</returns>
        IList<T> Get(Expression<Func<T, bool>> query);

        /// <summary>
        /// Get records from database with limit return records
        /// </summary>
        /// <param name="query">where condition</param>
        /// <param name="limit">limit records</param>
        /// <returns>records with</returns>
        IList<T> Get(Expression<Func<T, bool>> query, int limit);

        /// <summary>
        /// Select all records from database
        /// </summary>
        /// <returns>All records</returns>
        IList<T> All();

        /// <summary>
        /// Deletes the entity upon the defined query
        /// </summary>
        /// <param name="query">Delete Query</param>
        void Delete(Expression<Func<T, bool>> query);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="category">The entity to update</param>
        void Update(T category);

        /// <summary>
        /// filter data by filter condition
        /// </summary>
        /// <param name="filterCondition">
        /// <paramref name="filterCondition"/>
        /// </param>
        /// <returns></returns>
        IQueryable<T> Filter(FilterCondition filterCondition, out int total);

        /// <summary>
        /// Finds the specified key values.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        T Find(params object[] keyValues);

        List<T> ListAll();
    }
}
