//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Web;

//namespace Framework.Common.CacheServices
//{
//    public class HttpCacheService : ICacheService
//    {
//        IHttpContextAccessor _httpContextAccessor;
//        public HttpCacheService(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public void Set(string key, object data, TimeSpan timeSpan)
//        {
//            if (_httpContextAccessor.HttpContext.ca != null)
//            {
//                HttpContext.Current.Cache.Insert(key, data, null, DateTime.Now.Add(timeSpan), Cache.NoSlidingExpiration);
//            }
//        }

//        public object Get(string key)
//        {
//            if (HttpContext.Current != null)
//            {
//                return HttpContext.Current.Cache.Get(key);
//            }
//            return null;
//        }

//        public T Get<T>(string key)
//        {
//            object o = Get(key);

//            return (T)Convert.ChangeType(o, typeof(T), CultureInfo.CurrentCulture);
//        }

//        public bool Remove(string key)
//        {
//            if (string.IsNullOrEmpty(key)) return false;

//            if (HttpContext.Current != null)
//            {
//                return HttpContext.Current.Cache.Remove(key) != null;
//            }
//            return true;
//        }

//        public void Clear()
//        {
//            var cacheItems = HttpContext.Current.Cache.GetEnumerator();
//            while (cacheItems.MoveNext())
//            {
//                HttpContext.Current.Cache.Remove((string)cacheItems.Key);
//            }
//        }
//    }
//}
