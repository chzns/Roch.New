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
using System.Data;

using Roch.DomainModel;
using Roch.Framework;
using Roch.Database;

namespace Roch.CodeTool.GeneratedCode.Oracle
{
    /// <summary>
    /// 脚本生成 
    /// </summary>
    public class SQLCode : BaseCode
    {
        public SQLCode()
            : base()
        {
            m_TemplateType = TemplateType.SQLCode;
        }

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());

            StringBuilder sbFields = new StringBuilder(); //表字段
            StringBuilder sbInsertFieldFormat = new StringBuilder(); //添加实体格式
            StringBuilder sbUpdateFieldFormat = new StringBuilder();    //更新实体格式
            StringBuilder sbParameterTypes = new StringBuilder();       //参数类型格式            
            StringBuilder sbParameters = new StringBuilder();           //参数
            StringBuilder sbUpdateProduceFormat = new StringBuilder();  //更新存储过程格式
            string pkType = string.Empty;

            string lowerClassName = ConvertHelper.ToLower(m_ConfigInfo.ClassName);

            foreach (ColumnModel column in m_CurrentColumnModels)
            {
                string field = ConvertHelper.ToOracleField(column.Name);
                bool isLength = GetIsHaveFieldLength(column.TypeName);
                bool isScal = GetIsPericisionLength(column.TypeName);
                string typeDefault = string.Format("{0}{1}", column.TypeName, isLength ? string.Format("({0}{1})", isScal ? column.Precision : column.Length, string.Format(isScal ? string.Format(",{0}", column.Scale) : string.Empty)) : string.Empty);

                sbFields.AppendFormat("{0}, ", field);
                sbParameters.AppendFormat(":{0}, ", column.Name);

                sbInsertFieldFormat.AppendFormat("{0}, ", GetFormatValueByType(column.TypeName));
                sbUpdateFieldFormat.AppendFormat("{0}={1},", ConvertHelper.ToOracleField(column.Name), GetFormatValueByType(column.TypeName));
                sbParameterTypes.AppendLine(string.Format("\t{0} {1},", column.Name, typeDefault));

                if (m_ConfigInfo.PK == column.Name)
                {
                    pkType = typeDefault;
                }
                else
                {
                    sbUpdateProduceFormat.AppendFormat("{0}=:{1}, ", ConvertHelper.ToOracleField(column.Name), column.Name);
                }
            }

            if (sbFields.Length > 0)
            {
                sbFields = sbFields.Remove(sbFields.Length - 2, 2);
            }

            if (sbInsertFieldFormat.Length > 0)
            {
                sbInsertFieldFormat = sbInsertFieldFormat.Remove(sbInsertFieldFormat.Length - 2, 2);
            }

            if (sbUpdateFieldFormat.Length > 0)
            {
                sbUpdateFieldFormat = sbUpdateFieldFormat.Remove(sbUpdateFieldFormat.Length - 2, 2);
            }

            if (sbUpdateProduceFormat.Length > 0)
            {
                sbUpdateProduceFormat = sbUpdateProduceFormat.Remove(sbUpdateProduceFormat.Length - 2, 2);
            }

            if (sbParameters.Length > 0)
            {
                sbParameters = sbParameters.Remove(sbParameters.Length - 2, 2);
            }

            if (sbParameterTypes.Length > 0)
            {
                sbParameterTypes = sbParameterTypes.Remove(sbParameterTypes.Length - 3, 3);
            }

            //替换表名称$TableName$
            columnTemplate.Replace("$TableName$", ConvertHelper.ToOracleField(m_ConfigInfo.TableName));
            //替换主键类型$PKType$
            columnTemplate.Replace("$PKType$", pkType);
            //替换表字段$Fields$
            columnTemplate.Replace("$Fields$", sbFields.ToString());
            //替换表主键$PK$
            columnTemplate.Replace("$PK$", m_ConfigInfo.PK);
            //替换添加实体格式$InsertFieldFormat$
            columnTemplate.Replace("$InsertFieldFormat$", sbInsertFieldFormat.ToString());
            //替换更新实体格式$UpdateFieldFormat$
            columnTemplate.Replace("$UpdateFieldFormat$", sbUpdateFieldFormat.ToString());
            //替换实体参数$Parameters$
            columnTemplate.Replace("$Parameters$", sbParameters.ToString());
            //替换实体参数$Parameters$
            columnTemplate.Replace("$UpdateProduceFormat$", sbParameters.ToString());
            //替换实体参数$ParameterTypes$
            columnTemplate.Replace("$ParameterTypes$", sbParameterTypes.ToString());

            if (m_IsInsertData)
            {
                //替换脚本数据$InsertData$
                columnTemplate.Replace("$InsertData$", GeneratedInsertData(sbFields.ToString()));
            }

            return columnTemplate.ToString();
        }

        protected string GetFormatValueByType(string type)
        {
            string returnValue = "''";
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
                        returnValue = "";
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
                        returnValue = "''";
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
                        returnValue = "''";
                        break;
                    }
            }

            return returnValue;
        }

        public string GeneratedInsertData(string fields)
        {
            StringBuilder sbInsertData = new StringBuilder();
            DataTable dt = DatabaseMapper.Instance.FindDataByTable(ConvertHelper.ToOracleField(m_ConfigInfo.DatabaseName), ConvertHelper.ToOracleField(m_ConfigInfo.TableName));

            string insertTemplate = string.Empty;

            string cellFormat = string.Empty;
            string cellValue = string.Empty;

            foreach (DataRow row in dt.Rows)
            {              
                if (m_InsertCheckPK)
                {
                    #region 主键处理判断
                    string insertCondition = string.Empty;
                    List<ColumnModel> pkColumnModel = m_CurrentColumnModels.FindAll(c => c.IsPK);

                    foreach (ColumnModel col in pkColumnModel)
                    {
                        cellFormat = GetFormatDataFormatType(col.TypeName);

                        insertCondition += string.Format(string.Format("{0}='{1}' AND ", ConvertHelper.ToOracleField(col.Name), cellFormat.Substring(0, cellFormat.Length - 2)), GetDataValueByType(col.TypeName, row[col.Name]));
                    }

                    //插入数据的条件
                    if (pkColumnModel.Count > 0)
                    {
                        sbInsertData.AppendFormat("begin if wims_system.EXISTS2('select * from {0} where {1}')<1 then ", ConvertHelper.ToOracleField(m_ConfigInfo.TableName), insertCondition.Substring(0, insertCondition.Length - 4));
                    }
                    #endregion
                }

                insertTemplate = string.Format("INSERT INTO {0}({1}) VALUES(", ConvertHelper.ToOracleField(m_ConfigInfo.TableName), fields);

                sbInsertData.Append(insertTemplate);


                StringBuilder sbInsertValue = new StringBuilder();

                foreach (ColumnModel column in m_CurrentColumnModels)
                {
                    cellValue = GetDataValueByType(column.TypeName, row[column.Name]);
                    if (cellValue == NULL)
                    {
                        cellFormat = "{0}, ";
                    }
                    else
                    {
                        cellFormat = GetFormatDataFormatType(column.TypeName);
                    }

                    sbInsertValue.AppendFormat(cellFormat, cellValue);
                    //sbInsertValue.AppendFormat(GetFormatDataFormatType(column.TypeName), GetDataValueByType(column.TypeName, row[column.Name]));
                }

                if (sbInsertValue.Length > 2)
                {
                    sbInsertValue = sbInsertValue.Remove(sbInsertValue.Length - 2, 2);
                }

                sbInsertData.AppendLine(string.Format("{0});", sbInsertValue.ToString()));
                if (m_InsertCheckPK)
                {
                    sbInsertData.Append("end if;end;");
                }
            }

            if (!m_InsertCheckPK)
            {
                sbInsertData.Insert(0, "\r\n");
                sbInsertData.Insert(0, "begin");
                sbInsertData.AppendLine();
                sbInsertData.Append("end;");
            }

            return sbInsertData.ToString();
        }

        private string GetFormatDataFormatType(string type)
        {
            string returnValue = "'{0}', ";
            switch (type)
            {
                case "INT":
                case "BIGINT":
                case "DECIMAL":
                case "FLOAT":
                case "BIT":
                case "MONEY":                
                case "NUMBER":
                case "REAL":
                case "SMALLINT":
                case "SMALLMONEY":
                case "TINYINT":
                    {
                        returnValue = "{0}, ";
                        break;
                    }
                case "CHAR":                
                case "CHAR2":
                case "NCHAR":
                case "NTEXT":
                case "NVARCHAR2":
                case "NVARCHAR":
                case "UNIQUEIDENTIFIER":                
                case "VARCHAR2":
                case "VARCHAR":
                case "XML":
                case "SQL_VARIANT":
                case "SYSNAME":
                case "TEXT":
                
                    {
                        returnValue = "'{0}', ";
                        break;
                    }
                case "DATE":
                case "DATETIME":
                case "TIME":
                case "DATETIMEOFFSET":
                case "SMALLDATETIME":
                case "DATETIME2":
                case "TIMESTAMP":
                case "TIMESTAMP(6)":
                    {
                        returnValue = "{0}, ";
                        break;
                    }
                case "BINARY":
                case "VARBINARY":
                case "GEOGRAPHY":
                case "GEOMETRY":
                case "HIERARCHYID":
                case "IMAGE":                
                    {
                        returnValue = "{0}, ";
                        break;
                    }
            }

            return returnValue;
        }

        private string GetDataValueByType(string type, object value)
        {
            string returnValue = string.Empty;

            #region 判断
            if (value == null || value == DBNull.Value)
            {
                switch (type)
                {
                    case "INT":
                    case "BIGINT":
                    case "DECIMAL":
                    case "FLOAT":
                    case "BIT":
                    case "MONEY":
                    case "NUMBER":
                    case "REAL":
                    case "SMALLINT":
                    case "SMALLMONEY":
                    case "TINYINT":
                        {
                            returnValue = "0";
                            break;
                        }

                    case "DATE":
                    case "DATETIME":
                    case "DATETIME2":
                    case "DATETIMEOFFSET":
                    case "SMALLDATETIME":
                    case "TIME":
                    case "TIMESTAMP":
                        {
                            returnValue = "NULL";
                            break;
                        }
                    case "CHAR":
                    case "NCHAR":
                    case "NTEXT":
                    case "NVARCHAR":
                    case "NVARCHAR2":
                    case "VARCHAR":
                    case "VARCHAR2":
                    case "XML":
                    case "SQL_VARIANT":
                    case "SYSNAME":
                    case "TEXT":
                        {
                            returnValue = "NULL";
                            break;
                        }
                    case "UNIQUEIDENTIFIER":
                        {
                            returnValue = Guid.NewGuid().ToString();
                            break;
                        }
                    case "BINARY":
                    case "VARBINARY":
                    case "GEOGRAPHY":
                    case "GEOMETRY":
                    case "HIERARCHYID":
                    case "IMAGE":                    
                        {
                            returnValue = "NULL";
                            break;
                        }
                }

                return returnValue;
            }
            #endregion

            switch (type)
            {
                case "INT":
                case "BIGINT":
                case "DECIMAL":
                case "FLOAT":
                case "BIT":
                case "MONEY":
                case "NUMBER":
                case "REAL":
                case "SMALLINT":
                case "SMALLMONEY":
                case "TINYINT":               
                case "CHAR":
                case "NCHAR":
                case "NTEXT":
                case "NVARCHAR":
                case "VARCHAR":
                case "VARCHAR2":
                case "NVARCHAR2":                
                case "XML":
                case "SQL_VARIANT":
                case "SYSNAME":
                case "TEXT":
                case "UNIQUEIDENTIFIER":
                    {
                        returnValue = value.ToString();
                        break;
                    }
                case "DATE":
                case "DATETIME":
                case "DATETIME2":
                    {
                        returnValue = string.Format("to_date('{0}','yyyy.mm.dd hh24:mi:ss')", value);
                        break;
                       
                    }
                case "DATETIMEOFFSET":
                case "SMALLDATETIME":
                case "TIME":
                case "TIMESTAMP":
                    {
                        returnValue = string.Format("to_date('{0}','yyyy.mm.dd hh24:mi:ss')", value);
                        break;
                    }
                case "TIMESTAMP(6)":
                    {
                        DateTime findDateTime = (DateTime)value;
                        returnValue = string.Format("to_timestamp('{0}','yyyy-mm-dd hh24:mi:ss.ff')", findDateTime.ToString("yyyy-MM-dd HH:mm:ss.Ms"));
                        break;
                    }
                case "BINARY":
                case "VARBINARY":
                case "GEOGRAPHY":
                case "GEOMETRY":
                case "HIERARCHYID":
                case "IMAGE":               
                    {
                        returnValue = string.Format("0x{0}", ConvertHelper.ByteArrayToHexString((byte[])value));

                        break;
                    }
            }

            return returnValue;
        }
    }
}
