//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :DomainObject
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Roch.DomainModel
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class DomainObject
    {
        private ulong m_ID;
        private string m_Name;

        /// <summary>
        /// 主键
        /// </summary>
        public ulong ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
    }
}
