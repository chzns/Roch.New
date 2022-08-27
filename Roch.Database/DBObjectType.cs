//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :DBObjectType
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Roch.Database
{
    /// <summary>
    /// 数据库元素类型
    /// </summary>
    public class DBObjectType
    {
        /// <summary>
        /// 表格
        /// </summary>
        public const string Table = "U";

        /// <summary>
        /// 视图
        /// </summary>
        public const string View = "V";

        /// <summary>
        /// 存储过程
        /// </summary>
        public const string Procedure="P";
    }
}
