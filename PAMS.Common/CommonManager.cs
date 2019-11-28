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

    }
}
