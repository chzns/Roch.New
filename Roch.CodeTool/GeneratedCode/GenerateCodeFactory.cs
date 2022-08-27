//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :BaseCode
//        description :
//
//        created by lijinzhao at  12/21/2011 4:17:07 PM
//        Email :roch.lijinzhao1949@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

using Roch.DomainModel;
using Roch.Framework;
using Roch.Framework.Configuration;

namespace Roch.CodeTool.GeneratedCode
{
    /// <summary>
    /// 生成类工厂
    /// </summary>
    public class GenerateCodeFactory
    {
        public static BaseCode CreateGenerateCode(TemplateType templateType, DatabaseType dbType)
        {
            ConfigFileSection webSetting = ConfigFileManager.GetConfigFile();

            if (templateType==TemplateType.Repository)
            {
                string a = "";
            }
            dbType = DatabaseType.SQLServer2008;
            string refectorClass = webSetting.FileMarksSetting[string.Format("{0}_{1}", dbType, templateType)].processClass;
        
           return Reflector.Reflect(refectorClass) as BaseCode;
        }
    }
}
