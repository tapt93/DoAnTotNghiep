using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common.CacheServices
{
    public interface ICacheService
    {
        /// <summary>
        /// Set object to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="timeSpan"></param>
        void Set(string key, object data, TimeSpan timeSpan);

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <param name="key">Key of object</param>
        /// <returns>Cache value</returns>
        object Get(string key);

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Key of object</param>
        /// <returns>Cache value</returns>
        T Get<T>(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        bool Remove(string key);

        /// <summary>
        /// 
        /// </summary>
        void Clear();
    }
}
