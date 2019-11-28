using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Redis;


namespace PAMS.Common
{
    //用来放配置信息的静态类
    public static class RedisConfig
    {
        public static string configname { get; set; }

        public static string Connection { get; set; }

        public static int DefaultDataBase { get; set; }

        public static string InstanceName { get; set; }
    }
}
