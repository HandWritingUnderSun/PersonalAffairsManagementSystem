﻿using System;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;
using System.DrawingCore.Imaging;
using System.IO;
using Color = System.DrawingCore.Color;
using Point = System.DrawingCore.Point;
using PointF = System.DrawingCore.PointF;
using SizeF = System.DrawingCore.SizeF;

namespace PAMS.Common.Helper
{
    public class CheckCodeHelper
    {
        #region 单例模式
        //创建私有化静态obj锁  
        private static readonly object _ObjLock = new object();
        //创建私有静态字段，接收类的实例化对象  
        private static CheckCodeHelper _CheckCodeHelper = null;
        //构造函数私有化  
        private CheckCodeHelper() { }
        //创建单利对象资源并返回  
        public static CheckCodeHelper GetSingleObj()
        {
            if (_CheckCodeHelper == null)
            {
                lock (_ObjLock)
                {
                    if (_CheckCodeHelper == null)
                        _CheckCodeHelper = new CheckCodeHelper();
                }
            }
            return _CheckCodeHelper;
        }
        #endregion

        #region 生产验证码
        /// <summary>
        /// 1.数字验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string CreateNumberCheckCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值  
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字  
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);
            }
            //抽取随机数字  
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码  
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        /// <summary>
        /// 2.字母验证码
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns>验证码字符</returns>
        private string CreateAbcCheckCode(int length)
        {
            char[] verification = new char[length];
            char[] dictionary = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                verification[i] = dictionary[random.Next(dictionary.Length - 1)];
            }
            return new string(verification);
        }

        /// <summary>
        /// 3.混合验证码
        /// </summary>
        /// <param name="length">字符长度</param>
        /// <returns>验证码字符</returns>
        private string CreateMixCheckCode(int length)
        {
            char[] verification = new char[length];
            char[] dictionary = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                verification[i] = dictionary[random.Next(dictionary.Length - 1)];
            }
            return new string(verification);
        }

        /// <summary>
        /// 产生验证码，根据数据库s_constant设置的位数
        /// </summary>
        /// <param name="type">验证码类型：数字，字符，符合</param>
        /// <returns></returns>
        public string CreateCheckCode(CheckCodeType type)
        {
            string checekCode = string.Empty;
            Random random = new Random();

            //验证码位数
            int length = random.Next(4, 6);
            switch (type)
            {
                case CheckCodeType.NumberCheckCode:
                    checekCode = GetSingleObj().CreateNumberCheckCode(length);
                    break;
                case CheckCodeType.AbcCheckCode:
                    checekCode = GetSingleObj().CreateAbcCheckCode(length);
                    break;
                case CheckCodeType.MixCheckCode:
                    checekCode = GetSingleObj().CreateMixCheckCode(length);
                    break;
            }
            return checekCode;
        }
        #endregion

        #region 验证码图片
        /// <summary>
        /// 验证码图片 => Bitmap
        /// </summary>
        /// <param name="verifyCode">验证码</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns>Bitmap</returns>
        public Bitmap CreateBitmapByImgCheckCode(string checekCode, int width, int height)
        {
            Font font = new Font("Arial", 14, (FontStyle.Bold | FontStyle.Italic));
            Brush brush;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            SizeF totalSizeF = g.MeasureString(checekCode, font);
            SizeF curCharSizeF;
            PointF startPointF = new PointF(0, (height - totalSizeF.Height) / 2);
            Random random = new Random(); //随机数产生器
            g.Clear(Color.White); //清空图片背景色  
            for (int i = 0; i < checekCode.Length; i++)
            {
                brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                g.DrawString(checekCode[i].ToString(), font, brush, startPointF);
                curCharSizeF = g.MeasureString(checekCode[i].ToString(), font);
                startPointF.X += curCharSizeF.Width;
            }

            //画图片的干扰线  
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(bitmap.Width);
                int x2 = random.Next(bitmap.Width);
                int y1 = random.Next(bitmap.Height);
                int y2 = random.Next(bitmap.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //画图片的前景干扰点  
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            g.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1); //画图片的边框线  
            g.Dispose();
            return bitmap;
        }

        /// <summary>
        /// 验证码图片 => byte[]
        /// </summary>
        /// <param name="verifyCode">验证码</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns>byte[]</returns>
        public byte[] CreateByteByImgCheckCode(string checkCode, int width, int height)
        {
            Font font = new Font("Arial", 14, (FontStyle.Bold | FontStyle.Italic));
            Brush brush;
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            SizeF totalSizeF = g.MeasureString(checkCode, font);
            SizeF curCharSizeF;
            PointF startPointF = new PointF(0, (height - totalSizeF.Height) / 2);
            Random random = new Random(); //随机数产生器
            g.Clear(Color.White); //清空图片背景色  
            for (int i = 0; i < checkCode.Length; i++)
            {
                brush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)), Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
                g.DrawString(checkCode[i].ToString(), font, brush, startPointF);
                curCharSizeF = g.MeasureString(checkCode[i].ToString(), font);
                startPointF.X += curCharSizeF.Width;
            }

            //画图片的干扰线  
            for (int i = 0; i < 10; i++)
            {
                int x1 = random.Next(bitmap.Width);
                int x2 = random.Next(bitmap.Width);
                int y1 = random.Next(bitmap.Height);
                int y2 = random.Next(bitmap.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //画图片的前景干扰点  
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(bitmap.Width);
                int y = random.Next(bitmap.Height);
                bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            g.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1); //画图片的边框线  
            g.Dispose();

            //保存图片数据  
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Jpeg);
            //输出图片流  
            return stream.ToArray();
        }
        #endregion
    }

    public enum CheckCodeType { NumberCheckCode, AbcCheckCode, MixCheckCode };
}
