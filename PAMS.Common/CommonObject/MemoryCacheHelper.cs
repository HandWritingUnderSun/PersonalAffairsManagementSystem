using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PAMS.Common.CommonObject
{
    //MemoryCacheHelper
    public class MemoryCacheHelper
    {
        ////这里可以做成依赖注入，但没打算做成通用类库，所以直接把选项封在帮助类里边了
        //public MemoryCacheHelper(MemoryCacheOptions options)
        //{
        //    this._cache = new MemoryCache(options);
        //    this._cache = new MemoryCache(new MemoryCacheOptions());  
        //}
        ////这里可以做成依赖注入，但没打算做成通用类库，所以直接把选项封在帮助类里边了
        //public MemoryCacheHelper(MemoryCacheOptions options)
        //{
        //    this._cache = new MemoryCache(options);
        //}
        public static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 是否存在此缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            object v = null;
            return _cache.TryGetValue<object>(key,out v);
        }


        public T GetCache<T>(string key) where T : class
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            T v = null;
            _cache.TryGetValue<T>(key,out v);

            return v;
        }
    }
}
