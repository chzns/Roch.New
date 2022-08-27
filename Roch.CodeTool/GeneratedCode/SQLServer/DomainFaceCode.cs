﻿//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :DomainFaceCode
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

using Roch.Framework;
using Roch.DomainModel;

namespace Roch.CodeTool.GeneratedCode.SQLServer
{
    /// <summary>
    /// 生成外观代码
    /// </summary>
    public class DomainFaceCode : BaseCode
    {
        public DomainFaceCode()
            : base()
        {
            m_TemplateType = TemplateType.Face;
        }

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());

            //替换主键类型$PKType$
            columnTemplate.Replace("$PKType$", m_ConfigInfo.PKType);

            return columnTemplate.ToString();
        }
    }
}
