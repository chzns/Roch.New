//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :FileUtility
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.IO;

//using Roch.Framework.Configuration;

namespace Roch.DomainModel
{
    /// <summary>
    /// 文件读取类
    /// </summary>
    public class FileUtility
    {
        public static string ReadTemplate(string fileName)
        {
            string templateCountent = string.Empty;

            //try
            //{
            //    ConfigFileSection webSetting = ConfigFileManager.GetConfigFile();
            //    fileName = webSetting.FileMarksSetting[type.ToString()].path;
            //}
            //catch
            //{
            //    return templateCountent;
            //}          

            //判断文件是否存在
            string filePath = string.Format("Template/{0}", fileName);
            string path = System.IO.Path.GetFullPath(filePath);
            if (!File.Exists(path))
            {
                return null;
            }

            Encoding utf8 = Encoding.UTF8;
            using (StreamReader reader = new StreamReader(path, utf8))
            {
                templateCountent = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
            }

            return templateCountent;
        }
    }
}
