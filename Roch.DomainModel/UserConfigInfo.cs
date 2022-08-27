//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :TableModel
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
    /// 用户配置信息
    /// </summary>
    public class UserConfigInfo
    {
        private string m_DatabaseName;
        private string m_UserName;
        private string m_Email;
        private string m_TableName;
        private string m_NameSpace;
        private string m_ClassName;
        private string m_ClassDescription;
        private bool m_IsUsePK;
        private string m_PK;
        private string m_PKType;
        private int m_PKLength;        

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName
        {
            get { return m_DatabaseName; }
            set { m_DatabaseName = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName
        {
            get { return m_TableName; }
            set { m_TableName = value; }
        }

        /// <summary>
        /// 名称空间
        /// </summary>
        public string NameSpace
        {
            get { return m_NameSpace; }
            set { m_NameSpace = value; }
        }

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName
        {
            get { return m_ClassName; }
            set { m_ClassName = value; }
        }

        /// <summary>
        /// 类描述
        /// </summary>
        public string ClassDescript
        {
            get { return m_ClassDescription; }
            set { m_ClassDescription = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string PK
        {
            get { return m_PK; }
            set { m_PK = value; }
        }

        /// <summary>
        /// 主键类型
        /// </summary>
        public string PKType
        {
            get { return m_PKType; }
            set { m_PKType = value; }
        }

        /// <summary>
        /// 主键长度
        /// </summary>
        public int PKLength
        {
            get { return m_PKLength; }
            set { m_PKLength = value; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsUsePK
        {
            get { return m_IsUsePK; }
            set { m_IsUsePK = value; }
        }
    }
}
