//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :ConvertHelper
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Roch.Framework
{
    public class ConvertHelper
    {
        /// <summary>
        /// 转换为首字母大写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(string value)
        {
            value = value.Trim('[', ']');
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            return textInfo.ToTitleCase(value);
        }

        /// <summary>
        /// 转换为小写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLower(string value)
        {
            return value.ToLower();
        }

        /// <summary>
        /// 转换为数据字段
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToField(string value)
        {
            value = value.Trim('[', ']');
            value = string.Format("[{0}]", value);

            return value;
        }

        /// <summary>
        /// 转换成Oracle字段
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToOracleField(string value)
        {
            return value;
        }

        /// <summary>
        ///转换byte为两位十六进制字符串
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public static string ByteToHexString(byte byteData)
        {
            string result = string.Empty;
            result = byteData.ToString("X");//ToString("x")转换为小写
            if (result.Length == 1)
                result = "0" + result;
            return result;
        }

        /// <summary>
        /// 转换byte数组为以空格分隔的十六进制字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            string result = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                result += ByteToHexString(data[i]);
                result += "";
            }

            return result.TrimEnd();
        }
    }
}
