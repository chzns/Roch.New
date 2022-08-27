//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :ColumnModel
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
    /// 数据表列实体
    /// </summary>
    public class ColumnModel : DomainObject
    {
        private string m_ObjectName;
        private int m_ColumnOrder;
        private string m_TypeName;
        private bool m_IsPK;
        private bool m_IsNull;
        private bool m_IsIdentity;
        private int m_Length;
        private int m_Precision;
        private int m_Scale;
        private string m_DefaultValue;
        private string m_Description;

        /// <summary>
        /// 对象名称
        /// </summary>
        public string ObjectName
        {
            get { return m_ObjectName; }
            set { m_ObjectName = value; }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get { return m_TypeName; }
            set { m_TypeName = value; }
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        public bool IsNull
        {
            get { return m_IsNull; }
            set { m_IsNull = value; }
        }

        /// <summary>
        /// 列顺序
        /// </summary>
        public int ColumnOrder
        {
            get { return m_ColumnOrder; }
            set { m_ColumnOrder = value; }
        }

        /// <summary>
        /// 是否标识
        /// </summary>
        public bool IsIdentity
        {
            get { return m_IsIdentity; }
            set { m_IsIdentity = value; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPK
        {
            get { return m_IsPK; }
            set { m_IsPK = value; }
        }

        /// <summary>
        /// 长度
        /// </summary>
        public int Length
        {
            get { return m_Length; }
            set { m_Length = value; }
        }

        /// <summary>
        /// 精度
        /// </summary>
        public int Precision
        {
            get { return m_Precision; }
            set { m_Precision = value; }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        public int Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue
        {
            get { return m_DefaultValue; }
            set { m_DefaultValue = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }


    }
}
