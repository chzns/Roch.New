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

namespace Roch.Framework
{
    /// <summary>
    /// 数据库类型工具
    /// </summary>
    public class DBTypeUtilily
    {
        public static string DBTypeToCS(string dbType)
        {
            string csType = null;
            switch (dbType.ToLower())
            {
                //整型
                case "bigint":
                    csType = "long";
                    break;
                case "decimal":
                    csType = "decimal";
                    break;
                case "float":
                    csType = "float";
                    break;
                case "binary":
                    csType = "byte[]";
                    break;
                case "bit":
                    csType = "bool";
                    break;
                case "char":
                    csType = "string";
                    break;
                case "date":
                    csType = "DateTime";
                    break;
                case "datetime":
                    csType = "DateTime";
                    break;
                case "datetime2":
                    csType = "DateTime";
                    break;
                case "datetimeoffset":
                    csType = "DateTimeOffset";
                    break;
                //球面数据
                case "geography":
                //平面数据
                case "geometry":
                //用于组织结构
                case "hierarchyid":
                //图片
                case "image":
                    csType = "string";
                    break;
                case "int":
                    csType = "int";
                    break;
                case "money":
                    csType = "decimal";
                    break;
                case "nchar":
                    csType = "string";
                    break;
                case "ntext":
                    csType = "string";
                    break;
                case "numeric":
                    csType = "decimal";
                    break;
                case "nvarchar":
                    csType = "string";
                    break;
                //2008新增 等同float(24)
                case "real":
                    csType = "float";
                    break;
                case "smalldatetime":
                    csType = "DateTime";
                    break;
                case "smallint":
                    csType = "short";
                    break;
                case "smallmoney":
                    csType = "decimal";
                    break;
                case "sql_variant":
                    csType = "string";
                    break;
                case "sysname":
                case "text":
                    csType = "string";
                    break;
                case "time":
                    csType = "DateTime";
                    break;
                case "timestamp":
                    csType = "byte[]";
                    break;
                case "tinyint":
                    csType = "short";
                    break;
                case "uniqueidentifier":
                    csType = "Guid";
                    break;
                case "varbinary":
                    csType = "string";
                    break;
                case "varchar":
                    csType = "string";
                    break;
                case "xml":
                    csType = "string";
                    break;
                default:
                    csType = "string";
                    break;
            }

            return csType;
        }

        public static string OracleDBTypeToCS(string dbType, int length, int precision, int scale)
        {
            string csType = string.Empty;

            switch (dbType.ToUpper())
            {
                case "CHAR":
                    if (length == 36)
                    {
                        csType = "Guid";
                    }
                    else
                    {
                        csType = "string";
                    }
                    break;
                case "NUMBER":
                    if (precision == 1)
                    {
                        csType = "bool";
                    }
                    else if (precision > 1 && scale == 0)
                    {
                        csType = "int";
                    }
                    else
                    {
                        csType = "decimal";
                    }
                    break;
                case "VARCHAR2":
                case "NCHAR":
                case "NVARCHAR2":
                    csType = "string";
                    break;
                case "DATE":
                    csType = "DateTime";
                    break;
                case "TIMESTAMP":
                    csType = "byte[]";
                    break;
                case "FLOAT":
                    csType = "float";
                    break;
                case "INTEGER":
                case "LONG":
                case "LONG RAW":
                case "RAW":
                case "ROWID":
                case "UROWID":
                case "BLOB":
                case "CLOB":
                case "NCLOB":
                case "BFILE":
                case "INTERVAL YEAR":
                case "INTERVAL DAY":
                case "BINARY_DOUBLE":
                case "BINARY_FLOAT":
                case "XMLTYPE":
                    csType = "string";
                    break;
                default:
                    break;
            }

            return csType;
        }

        public static int ShowNullPrecision(string type, int value)
        {
            if (string.IsNullOrEmpty(type))
            {
                return 0;
            }

            int nullValue = value;

            switch (type)
            {
                case "int":
                case "bigint":
                case "smallint":
                case "datetime":
                case "bit":
                    nullValue = 0;
                    break;
            }

            return nullValue;
        }
    }
}
