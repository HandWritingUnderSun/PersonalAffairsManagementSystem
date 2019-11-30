using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PAMS.Common.CommonObject
{
    //然后ICacheHelper.cs，这个类是两种缓存通用的接口，让使用更方便
    public interface ICacheHelper
    {
        bool Exists(string key);

        T GetCache<T>(string key) where T : class;

        void SetCache(string key ,object value);

        void SetCache(string key, object value, DateTimeOffset expiressAbsoulte);//设置绝对时间过期

        void SetSlidingCache(string key,object value,TimeSpan t);//设置滑动过期，因Redis暂未找到自带的滑动过期类的API，暂无需实现该接口

        void RemoveCache(string key);

        void KeyMigrate(string key,EndPoint endPoint,int database,int timeoutseconds);

        void Dispose();

        void GetMessages();

        void Publish(string msg);
    }
}
