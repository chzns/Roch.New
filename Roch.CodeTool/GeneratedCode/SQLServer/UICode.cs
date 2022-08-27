//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :UICode
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

using Roch.DomainModel;
using Roch.Framework;

namespace Roch.CodeTool.GeneratedCode.SQLServer
{
    /// <summary>
    /// 生成界面代码
    /// </summary>
    public class UICode : BaseCode
    {
        public UICode()
            : base()
        {
            m_TemplateType = TemplateType.UI;
        }        

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());

            return columnTemplate.ToString();
        }
    }
}
