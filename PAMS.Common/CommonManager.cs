using System;
using System.Collections.Generic;
using System.Text;
using PAMS.Common.CommonObject;

namespace PAMS.Common
{
    public class CommonManager
    {
        private static readonly object lockobj = new object();
        private static volatile Cache _cache = null;

        public static Cache CacheObj
        {
            get
            {
                if (_cache == null)
                {
                    lock (lockobj)
                    {
                        if (_cache == null)
                        {
                            _cache = new Cache();
                        }
                    }
                }
                return _cache;
            }
        }
    }
}
