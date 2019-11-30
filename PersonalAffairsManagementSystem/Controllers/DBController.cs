using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PAMS.Common;
using PAMS.Common.CommonObject;

namespace PersonalAffairsManagementSystem.Controllers
{
    public class DBController : Controller
    {
        public IActionResult Index()
        {
            for (int i = 0; i < 100000; i++)
            {
                CommonManager.CacheObj.Save<RedisCacheHelper>("key" + i, "key" + i + " works!");
            }
            return View();
        }

        public IActionResult GetJsonString(int index)
        {
            string res = "已经过期了";
            if (CommonManager.CacheObj.Exists<RedisCacheHelper>("key" + index))
            {
                res = CommonManager.CacheObj.GetCache<String, RedisCacheHelper>("key" + index);
            }
            return Json(new ExtJson { success = true, code = 1000, msg = "成功", jsonresult = res });
        }

        public IActionResult Publish(string msg)
        {
            try
            {
                CommonManager.CacheObj.Publish<RedisCacheHelper>(msg);
                return Json(new ExtJson { success = true, code = 1000, msg = "成功", jsonresult = msg });
            }
            catch
            {
                return Json(new ExtJson
                {
                    success = true,
                    code = 1000,
                    msg = "失败",
                    jsonresult = msg
                });
            }
        }
    }
}