using Framework.DynamicQuery;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Common.Service
{
    /// <summary>
    /// Implement of IBaseService <see cref="IBaseService{T,DC}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="DC"></typeparam>
    public class BaseService<T, DC> : IBaseService<T, DC>
        where T : class, new()
        where DC : DbContext, new()
    {
        public readonly ILogger Logger;
        public readonly DC dc;

        public BaseService(ILogger logger, DC dc)
        {
            Logger = logger;
            this.dc = dc;
        }
        /// <summary>
        /// Adds a new record to the DB
        /// </summary>
        /// <param name="entity">Current Object</param>
        /// <param name="IdPropertyName">Name of the property containing identity Column or the ID returned by the DB</param>
        /// <returns><see cref="System.Object"/> </returns>
        public virtual object Add(T entity, string IdPropertyName)
        {
            using (var transaction = this.dc.Database.BeginTransaction())
            {
                try
                {
                    dc.Set<T>().Add(entity);
                    dc.SaveChanges();
                    transaction.Commit();
                    var property = entity.GetType().GetProperty(IdPropertyName);

                    if (property != null)
                        return property.GetValue(entity, null);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                return null;
            }
        }

        /// <summary>
        /// Adds a new record to the DB
        /// </summary>
        /// <param name="entity">Object entity to add</param>
        /// <returns>Object entity return</returns>
        public virtual T Add(T entity)
        {
            using (var transaction = this.dc.Database.BeginTransaction())
            {
                try
                {
                    dc.Set<T>().Add(entity);
                    dc.SaveChanges();
                    transaction.Commit();
                    return entity;
                }
                catch (ValidationException ex)
                {
                    transaction.Rollback();
                    Logger.LogInformation(ex, ex.Message);
                    throw;
                }
            }
        }

        /// <summary>
        /// Add list entity to the DB
        /// </summary>
        /// <param name="entities">A collection of entity</param>
        public virtual void Add(IList<T> entities)
        {
            using (var transaction = this.dc.Database.BeginTransaction())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        dc.Set<T>().Add(entity);
                    }
                    dc.SaveChanges();
                    transaction.Commit();
                }
                catch (ValidationException ex)
                {
                    transaction.Rollback();
                    Logger.LogInformation(ex, ex.Message);
                    throw;
                }
            }

        }

        /// <summary>
        /// Get records from database
        /// </summary>
        /// <param name="query">where condition</param>
        /// <returns>records with</returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> query)
        {
            Logger.LogTrace("Get records from database with limit return records");
            Logger.LogInformation("Get records from database with limit return records");

            var q = dc.Set<T>().AsQueryable();

            if (query != null)
            {
                q = q.Where(query);
            }

            return q.ToList();
        }

        /// <summary>
        /// Get records from database with limit return records
        /// </summary>
        /// <param name="query">where condition</param>
        /// <param name="limit">limit records</param>
        /// <returns>records with</returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> query, int limit)
        {
            var q = dc.Set<T>().AsQueryable();

            if (query != null)
            {
                q = q.Where(query);
            }

            return q.Take(limit).ToList();
        }

        /// <summary>
        /// Select all records from database
        /// </summary>
        /// <returns>All records</returns>
        public virtual IList<T> All()
        {
            return dc.Set<T>().ToList();
        }

        /// <summary>
        /// Deletes the entity upon the defined query
        /// </summary>
        /// <param name="query">Delete Query</param>
        public virtual void Delete(Expression<Func<T, bool>> query)
        {
            using (var transaction = this.dc.Database.BeginTransaction())
            {
                try
                {
                    IQueryable<T> result = dc.Set<T>().Where(query);

                    foreach (T item in result)
                    {
                        dc.Set<T>().Remove(item);
                    }

                    if (result.Count() > 0)
                        dc.SaveChanges();
                    transaction.Commit();
                }
                catch (ValidationException ex)
                {
                    transaction.Rollback();
                    Logger.LogInformation(ex, ex.Message);
                    throw;
                }
            }

        }

        /// <summary>
        /// Updates Entity
        /// </summary>
        /// <param name="category">Entity which hold the updated information</param>
        public virtual void Update(T category)
        {
            using (var transaction = this.dc.Database.BeginTransaction())
            {
                try
                {
                    dc.Set<T>().Attach(category);

                    dc.Entry<T>(category).State = EntityState.Modified;
                    dc.SaveChanges();
                    transaction.Commit();
                }
                catch (ValidationException ex)
                {
                    transaction.Rollback();
                    Logger.LogInformation(ex, ex.Message);
                    throw;
                }
            }
        }

        public IQueryable<T> Get(IQuery<T> query)
        {
            return query.Filter(dc.Set<T>());
        }

        public IQueryable<T> Filter(FilterCondition filterCondition, out int total)
        {

            Query<T> query = Query<T>.Create(c => (1 == 1));
            foreach (var searchCondition in filterCondition.SearchCondition)
            {
                query = query.And(Query<T>.Create(searchCondition.FieldName, searchCondition.OperationType, searchCondition.Value));
            }
            total = 0;
            if (filterCondition.Paging)
            {
                total = query.Filter(dc.Set<T>()).Count();
                var queryable = Get(query);
                foreach (var order in filterCondition.Orders)
                {
                    if (order.OrderDesc)
                    {
                        queryable = queryable.OrderByProperty(order.FieldName);
                    }
                    else
                    {
                        queryable = queryable.OrderByPropertyDescending(order.FieldName);
                    }

                }
                var skip = (filterCondition.PageIndex - 1) * filterCondition.PageSize;
                return queryable.Skip(skip).Take(filterCondition.PageSize).AsNoTracking();
            }

            return Get(query);
        }

        /// <summary>
        /// Finds the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual T Find(params object[] keyValues)
        {
            T result = dc.Set<T>().Find(keyValues);

            return result;

        }

        public List<T> ListAll()
        {
            return dc.Set<T>().ToList();
        }
    }
}
