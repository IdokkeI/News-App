using Microsoft.Extensions.Caching.Memory;
using news_server.Features.Admin.Model;
using System;
using System.Collections.Generic;

namespace news_server.Infrastructure.Extensions
{
    public static class CacheExtension
    {
        public static void UpdateCacheAdd<T>(this IMemoryCache cache, string key, List<T> listObj, T objAdd)
        {
            listObj.Add(objAdd);
            cache.Remove(key);
            if (objAdd.GetType() == typeof(GetUser))
            {

            }
            cache
                .Set(
                    key,
                    listObj,
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    });            
        }
        
        
        public static void UpdateCacheDel<T>(this IMemoryCache cache, string key, List<T> listObj, T objDel)
        {
            listObj.Remove(objDel);
            cache.Remove(key);
            cache
                .Set(
                    key,
                    listObj,
                    new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    });            
        }
    }
}
