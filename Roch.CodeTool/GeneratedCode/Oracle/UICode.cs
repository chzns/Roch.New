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

using Roch.Framework;
using Roch.DomainModel;

namespace Roch.CodeTool.GeneratedCode.Oracle
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
