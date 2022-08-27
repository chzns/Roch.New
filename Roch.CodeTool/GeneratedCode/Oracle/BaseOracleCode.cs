//======================================================================
//
//        Copyright (C) 2011-2012 rochsoft
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

namespace Roch.CodeTool.GeneratedCode.Oracle
{
    public abstract class BaseOracleCode
    {
        protected string Tab = "    ";
        protected List<ColumnModel> m_CurrentColumnModels;
        protected UserConfigInfo m_ConfigInfo;
        protected string m_Template;
        protected bool m_IsInsertData; //是否生成插入数据

        public BaseOracleCode()
        {

        }

        public BaseOracleCode(UserConfigInfo configInfo, List<ColumnModel> columnModes, string template)
        {

        }

        public void SetBaseCode(UserConfigInfo configInfo, List<ColumnModel> columnModels, string template)
        {
            m_CurrentColumnModels = columnModels;
            m_ConfigInfo = configInfo;
            m_Template = template;
        }

        public void SetBaseCode(UserConfigInfo configInfo, List<ColumnModel> columnModels, string template, bool isInsertData)
        {
            SetBaseCode(configInfo, columnModels, template);
            m_IsInsertData = isInsertData;
        }

        public virtual string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(m_Template);
            string lowerClassName = ConvertHelper.ToLower(m_ConfigInfo.ClassName);

            //替换命名空间$NameSpace$
            columnTemplate.Replace("$NameSpace$", m_ConfigInfo.NameSpace);
            //替换用户名$UserName$
            columnTemplate.Replace("$UserName$", m_ConfigInfo.UserName);
            //替换时间$Datetime$
            columnTemplate.Replace("$Datetime$", DateTime.Now.ToString());
            //替换邮件$Email$
            columnTemplate.Replace("$Email$", m_ConfigInfo.Email);
            //替换类名称$ClassName$
            columnTemplate.Replace("$ClassName$", m_ConfigInfo.ClassName);
            //替换类描述$ClassDescript$
            columnTemplate.Replace("$ClassDescript$", m_ConfigInfo.ClassDescript);
            //替换小写类名称$LowerClassName$
            columnTemplate.Replace("$LowerClassName$", lowerClassName);

            return columnTemplate.ToString();
        }

        /// <summary>
        /// 去除首空行
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        protected string RemoveFirstRow(string sb)
        {
            if (sb.Length < 2)
            {
                return sb;
            }

            return sb.Remove(0, 2);
        }

        /// <summary>
        /// 去除第一个Tab
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        protected string RemoveFirstTab(string sb)
        {
            if (sb.Length < 1)
            {
                return sb;
            }

            return sb.Remove(0, 1);
        }

        /// <summary>
        /// 去除第一个Tab
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        protected string RemoveFirstTab(string sb, int count)
        {
            if (sb.Length < count)
            {
                return sb;
            }

            return sb.Remove(0, count);
        }

        /// <summary>
        /// 去除尾空行
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        protected string RemoveEndRow(string sb)
        {
            if (sb.Length < 2)
            {
                return sb;
            }

            return sb.Remove(sb.Length - 2, 2);
        }

        #region 数据层类型转换
        protected string GetFormatByType(string type, int index)
        {
            string returnValue = "'{" + index.ToString() + "}'";
            switch (type)
            {
                case "int":
                case "bigint":
                case "decimal":
                case "float":
                case "bit":
                case "money":
                case "numeric":
                case "real":
                case "smallint":
                case "smallmoney":
                case "tinyint":
                    {
                        returnValue = "{" + index.ToString() + "}";
                        break;
                    }
                case "char":
                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "smalldatetime":
                case "uniqueidentifier":
                case "varchar":
                case "xml":
                case "sql_variant":
                case "sysname":
                case "text":
                case "time":
                    {
                        returnValue = "'{" + index.ToString() + "}'";
                        break;
                    }
                case "binary":
                case "varbinary":
                case "geography":
                case "geometry":
                case "hierarchyid":
                case "image":
                case "timestamp":
                    {
                        returnValue = "{" + index.ToString() + "}";
                        break;
                    }
            }

            return returnValue;
        }

        protected string GetProcessStringByType(string type, string property)
        {
            string returnValue = string.Format("{0}.ToString()", property);

            switch (type)
            {
                case "int":
                case "bigint":
                case "decimal":
                case "float":
                case "bit":
                case "money":
                case "numeric":
                case "real":
                case "smallint":
                case "smallmoney":
                case "tinyint":
                case "uniqueidentifier":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "smalldatetime":
                case "varchar":
                case "xml":
                case "sql_variant":
                case "sysname":
                case "text":
                case "char":
                    {
                        returnValue = property;
                        break;
                    }
                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "time":
                    {
                        returnValue = string.Format("{0}.ToString()", property);
                        break;
                    }
                case "binary":
                case "varbinary":
                case "geography":
                case "geometry":
                case "hierarchyid":
                case "image":
                case "timestamp":
                    {
                        returnValue = string.Format("GeneratedByteArrayToString({0})", property);
                        break;
                    }
            }

            return returnValue;
        }

        protected string GetPropertyByType(string type)
        {
            string returnValue = "GetRowString";
            switch (type)
            {
                case "int":
                case "smallint":
                case "tinyint":
                    {
                        returnValue = "GetRowInt32";
                        break;
                    }
                case "bigint":
                    {
                        returnValue = "GetRowInt64";
                        break;
                    }
                case "decimal":
                case "float":
                case "money":
                case "numeric":
                case "real":
                case "smallmoney":
                    {
                        returnValue = "GetRowDecimal";
                        break;
                    }
                case "bit":
                    {
                        returnValue = "GetRowBoolean";
                        break;
                    }
                case "uniqueidentifier":
                    {
                        returnValue = "GetRowGuid";
                        break;
                    }
                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "smalldatetime":
                case "time":
                    {
                        returnValue = "GetRowDatatime";
                        break;
                    }
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar":
                case "xml":
                case "sql_variant":
                case "sysname":
                case "text":
                    {
                        returnValue = "GetRowString";
                        break;
                    }
                case "binary":
                case "varbinary":
                case "geography":
                case "geometry":
                case "hierarchyid":
                case "image":
                case "timestamp":
                    {
                        returnValue = "GetRowByteArray";
                        break;
                    }
            }

            return returnValue;
        }

        protected bool GetIsHaveFieldLength(string type)
        {
            bool returnValue = false;
            switch (type)
            {
                case "decimal":
                case "float":
                case "money":
                case "numeric":
                case "real":
                case "smallmoney":
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "varchar":
                case "xml":
                case "sql_variant":
                case "sysname":
                case "text":
                    {
                        returnValue = true;
                        break;
                    }
            }

            return returnValue;
        }

        protected bool GetIsPericisionLength(string type)
        {
            bool returnValue = false;
            switch (type)
            {
                case "decimal":
                case "float":
                case "money":
                case "numeric":
                case "real":
                case "smallmoney":
                    {
                        returnValue = true;
                        break;
                    }
            }

            return returnValue;
        }
        #endregion
    }
}
