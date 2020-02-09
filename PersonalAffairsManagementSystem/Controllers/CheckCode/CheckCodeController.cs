using System;
using System.DrawingCore.Imaging;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PAMS.Common.Helper;
using PersonalAffairsManagementSystem.Models;

namespace PersonalAffairsManagementSystem.Controllers
{
    public class CheckCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 数字验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult NumberCheckCode()
        {
            string code = CheckCodeHelper.GetSingleObj().CreateCheckCode(CheckCodeType.NumberCheckCode,GetCheckCodeLen());
            byte[] codeImage = CheckCodeHelper.GetSingleObj().CreateByteByImgCheckCode(code, 100, 40);
            return File(codeImage, @"image/jpeg");
        }

        /// <summary>
        /// 字母验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult AbcCheckCode()
        {
            string code = CheckCodeHelper.GetSingleObj().CreateCheckCode(CheckCodeType.AbcCheckCode,GetCheckCodeLen());
            var bitmap = CheckCodeHelper.GetSingleObj().CreateBitmapByImgCheckCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }

        /// <summary>
                /// 混合验证码
                /// </summary>
                /// <returns></returns>
        public FileContentResult MixCheckCode()
        {
            string code = CheckCodeHelper.GetSingleObj().CreateCheckCode(CheckCodeType.MixCheckCode,GetCheckCodeLen());
            var bitmap = CheckCodeHelper.GetSingleObj().CreateBitmapByImgCheckCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }

        public int GetCheckCodeLen()
        {
            Random random = new Random();
            int result= random.Next(4, 6);
            S_ConstantDbContext context = new S_ConstantDbContext();
            if (!string.IsNullOrEmpty(context.s_Constants.Find("checkcodelength").CValue))
            {
                result=int.Parse(context.s_Constants.Find("checkcodelength").CValue);
            }
            return result;
        }
    }
}