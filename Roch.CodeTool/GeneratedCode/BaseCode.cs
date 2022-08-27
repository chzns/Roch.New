//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :BaseCode
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
using Roch.Framework.Configuration;
using Roch.Database;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Collections;

namespace Roch.CodeTool.GeneratedCode
{
    /// <summary>
    /// 生成基类
    /// </summary>    
    public class BaseCode
    {
        /// <summary>
        /// 占位符
        /// </summary>
        protected string Tab = "   ";
        protected string NULL = "NULL";
        protected List<ColumnModel> m_CurrentColumnModels;
        protected UserConfigInfo m_ConfigInfo;
        protected TemplateType m_TemplateType; //模板类型
        protected string m_Template;      //模板内容
        protected string m_TemplatePath;  //模板路径
        protected bool m_IsInsertData;    //是否生成插入数据      
        protected bool m_InsertCheckPK;   //插入数据是否检测


        public BaseCode()
        {
            m_Template = GetTemplatePath();
        }

        public void SetBaseCode(UserConfigInfo configInfo, List<ColumnModel> columnModels)
        {
            m_CurrentColumnModels = columnModels;
            m_ConfigInfo = configInfo;
            m_TemplatePath = GetTemplatePath();
            m_Template = FileUtility.ReadTemplate(m_TemplatePath);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="configInfo">自定义信息</param>
        /// <param name="columnModels">列集合</param>
        /// <param name="isInsertData">是否插入数据</param>
        /// <param name="insertCheckPK">插入数据是否检测</param>
        public void SetBaseCode(UserConfigInfo configInfo, List<ColumnModel> columnModels, bool isInsertData, bool insertCheckPK)
        {
            SetBaseCode(configInfo, columnModels);
            m_IsInsertData = isInsertData;
            m_InsertCheckPK = insertCheckPK;
        }

        public virtual string GetTemplatePath()
        {
            ConfigFileSection webSetting = ConfigFileManager.GetConfigFile();
            return webSetting.FileMarksSetting[string.Format("{0}_{1}", DatabaseMapper.Instance.DatabaseType, m_TemplateType)].path;
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
            //替换类描述$ClassDescription$
            columnTemplate.Replace("$ClassDescript$", m_ConfigInfo.ClassDescript);
            //替换小写类名称$LowerClassName$
            columnTemplate.Replace("$LowerClassName$", lowerClassName);

            return columnTemplate.ToString();
        }


        //public virtual string GeneratedCode()
        //{
        //    List<ModelClass> list = ConstConstants.modelClassList;
        //    return spp1(list);
        //}

        public string spp1(List<ModelClass> list)
        {
            var model = list.Where(m => m.Is_Identity == "True").FirstOrDefault();
            if (model == null)
            {
                model = list.FirstOrDefault();
            }

            var responseName = model.TableName.Replace("_", "").Trim().TrimStart() + "Repository";
            var tableName = model.TableName;

            StringBuilder sb = new StringBuilder();
            sb.Append("//1. SPP.Data.Repository." + responseName.ToString().ToStringToN());
            sb.Append("using SPP.Data.Infrastructure;".ToString().ToStringToN());
            sb.Append("using System;".ToString().ToStringToN());
            sb.Append("using System.Collections.Generic;".ToString().ToStringToN());
            sb.Append("using System.Data.SqlClient;".ToString().ToStringToN());
            sb.Append("using System.Linq;".ToString().ToStringToN());
            sb.Append("using System.Text;".ToString().ToStringToN());
            sb.Append("using System.Threading.Tasks;".ToString().ToStringToN());
            sb.Append("namespace SPP.Data.Repository".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("public class SupplierSAPTempRepository : RepositoryBase<Supplier_SAP_Temp>, ISupplierSAPTempRepository".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("public SupplierSAPTempRepository(IDatabaseFactory databaseFactory)".ToString().ToStringToN());
            sb.Append(": base(databaseFactory)".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("public interface ISupplierSAPTempRepository: IRepository<Supplier_SAP_Temp>".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            return sb.ToString();
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

        protected string GetOraclePKBegin(string type, int length)
        {
            if (type.ToUpper().Equals("GUID") && length == 36)
            {
                return "GenerateString(";
            }

            return string.Empty;
        }

        protected string GetOraclePKEnd(string type, int length)
        {
            if (type.ToUpper().Equals("GUID") && length == 36)
            {
                return ")";
            }

            return string.Empty;
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

        protected string GetOracleFormatByType(string type, int index, int precision)
        {
            string returnValue = "'{" + index.ToString() + "}'";

            switch (type.ToUpper())
            {
                case "CHAR":
                    break;
                case "NUMBER":
                    if (precision > 1)
                    {
                        returnValue = "{" + index.ToString() + "}";
                    }

                    break;
                case "VARCHAR2":
                case "NCHAR":
                case "NVARCHAR2":
                    break;
                case "DATE":
                    returnValue = "to_date('{" + index.ToString() + "}','yyyy-mm-dd hh24:mi:ss')";
                    break;
                case "TIMESTAMP":
                    break;
                case "FLOAT":
                    returnValue = "{" + index.ToString() + "}";
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
                    break;
                default:
                    break;
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
                case "money":
                case "numeric":
                case "real":
                case "smallint":
                case "smallmoney":
                case "tinyint":
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
                case "uniqueidentifier":
                    {
                        returnValue = property;
                        break;
                    }
                case "bit":
                    {
                        returnValue = string.Format("GenerateString({0})", property);
                        break;
                    }
                case "date":
                case "datetime":
                case "datetime2":
                case "datetimeoffset":
                case "time":
                    {
                        returnValue = string.Format("GenerateString({0})", property);
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
                        returnValue = string.Format("GenerateString({0})", property);
                        break;
                    }
            }

            return returnValue;
        }

        protected string GetOracleProcessStringByType(string type, string property, int length, int precision)
        {
            string returnValue = property;

            switch (type.ToUpper())
            {
                case "CHAR":
                    if (length == 36)
                    {
                        returnValue = string.Format("GenerateString({0})", property);
                    }
                    break;
                case "NUMBER":
                    if (precision == 1)
                    {
                        returnValue = string.Format("Convert.ToInt32({0})", property);
                    }
                    break;
                case "VARCHAR2":
                case "NCHAR":
                case "NVARCHAR2":
                    break;
                case "DATE":
                    break;
                case "TIMESTAMP":
                    returnValue = string.Format("GenerateString({0})", property);
                    break;
                case "FLOAT":
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
                    break;
                default:
                    break;
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

        protected string GetOraclePropertyByType(string type, int length, int precision, int scale)
        {
            string returnValue = "GetRowString";

            switch (type.ToUpper())
            {
                case "CHAR":
                    if (length == 36)
                    {
                        returnValue = "GetRowGuid";
                    }

                    break;
                case "NUMBER":
                    if (precision == 1)
                    {
                        returnValue = "GetRowBoolean";
                    }
                    else if (precision > 1 && scale == 0)
                    {
                        returnValue = "GetRowInt32";
                    }
                    else
                    {
                        returnValue = "GetRowDecimal";
                    }
                    break;
                case "VARCHAR2":
                case "NCHAR":
                case "NVARCHAR2":
                    break;
                case "DATE":
                    returnValue = "GetRowDatatime";
                    break;
                case "TIMESTAMP":
                    returnValue = "GetRowByteArray";
                    break;
                case "FLOAT":
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
                    break;
                default:
                    break;
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


        #region Hongzhong


        /// <summary>
        ///文本生成 ModelClass
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<ModelClass> GetModelClassList(string content)
        {
            List<ModelClass> list = new List<ModelClass>();
            //匹配内容
            Regex reg = new Regex(" public.*?{ get; set; }");//commend by danielinbiti  
            MatchCollection mc = reg.Matches(content);
            //内容处理 
            content = content.Replace("private", "public");
            content = content.Replace("PUBLIC", "public");
            content = content.Replace("CLASS", "class");
            content = content.Replace("protect", "public");
            content = content.Replace("PROTECT", "public");

            //model名称
            Regex regClass = new Regex(@"public class.*?\s\S*");
            MatchCollection mcName = regClass.Matches(content);
            var tempclassName = mcName[0].ToString().Replace(" ", ",");
            var tempNameList = tempclassName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            var className = tempNameList[2].ToString();
            className = className.Replace(":", "").Trim();

            foreach (Match m in mc)
            {
                var ColumnAll = m.Value.ToString();
                var model = new ModelClass();
                ColumnAll = ColumnAll.Replace("{ get; set; }", "");
                ColumnAll = ColumnAll.Replace(" ", ",");
                var temp = ColumnAll.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                model.ColumnType = temp[1].ToString().Trim();
                model.ColumnName = temp[2].ToString().Trim();
                model.TableName = className;


                switch (model.ColumnType.ToUpper())
                {
                    default:
                        model.ColumnDefaultValue = "NULL";
                        model.DataType = "NVARCHAR(200)";
                        //model.ColumnUI_Type = ConstColumnUI_Type.ui_input;

                        break;
                    case "SYSTEM.GUID":
                    case "GUID":
                    case "Nullable<Guid>":
                        model.ColumnDefaultValue = "Guid.NewGuid()";
                        model.DataType = "uniqueidentifier";
                        //model.ColumnUI_Type = ConstColumnUI_Type.ui_input;
                        break;
                    case "STRING":
                        model.ColumnDefaultValue = "String.Empty";
                        model.DataType = "NVARCHAR(200)";
                        //model.ColumnUI_Type = ConstColumnUI_Type.ui_input;
                        break;
                    case "INT":
                    case "INT?":
                        model.ColumnDefaultValue = "0";
                        model.DataType = "INT";
                        //model.ColumnUI_Type = ConstColumnUI_Type.ui_input;
                        break;
                    case "DATETIME":
                    case "DATETIME?":
                        model.ColumnDefaultValue = "DateTime.Now";
                        model.DataType = "DATETIME";
                        //model.ColumnUI_Type = ConstColumnUI_Type.ui_input;
                        break;
                }
                if (!string.IsNullOrEmpty(model.ColumnUI_Type))
                {
                    model.ColumnUI_ID = "js_" + model.ColumnUI_Type + "_" + model.ColumnName.ToLower(); ;
                }
                else
                {
                    model.ColumnUI_Type = ConstColumnUI_Type.ui_input;
                }
                //


                if (model.ColumnUI_Type == ConstColumnUI_Type.ui_input)
                {
                    model.ColumnUI_ID = ConstColumnUI_TypeValue.ui_input + model.ColumnName.ToLower();
                    model.ColumnUI_DisplayName = "displayname_" + model.ColumnName.ToLower();
                }

                list.Add(model);

            }
            //ConstConstants.modelClassList = list;

            var constlist = ConstConstants.mainModelList;
            if (constlist != null)
            {

                foreach (var item in constlist)
                {
                    foreach (var child in list)
                    {
                        if (item.Name.Trim().ToUpper() == child.ColumnName.ToUpper().Trim())
                        {
                            child.ColumnRemarks = item.Description;
                            child.DataType = item.TypeName;
                            child.Is_Identity = item.IsPK.ToString();
                            child.Is_Null = item.IsNull.ToString();


                        }

                    }

                }
            }

            return list;

        }

        public string GetResponeNameRule(string s)
        {

            return s.Substring(0, 1).ToUpper() + s.Substring(1).Replace("_", "").Trim();
        }


        /// <summary>
        /// 生成最终的脚本.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GeneratedModelClassByList(List<ModelClass> list)
        {

            StringBuilder sb_ALL = new StringBuilder();
            string className = string.Empty;
            if (list.Count > 0)
            {
                className = list[0].TableName.Trim();
                StringBuilder sb = new StringBuilder();




                //
                sb.Append(string.Format("{0}  model_{0} =new {0} ();", className));
                sb.Append("\n");
                foreach (var item in list)
                {
                    sb.Append(string.Format("model_{0}.", className) + item.ColumnName + "=" + item.ColumnDefaultValue + ";");
                    sb.Append("\n");

                }
                sb.Append("//-----1.简易Model赋值------");


                StringBuilder sb_1 = new StringBuilder();
                sb_1.Append(string.Format("{0}  newItem_{0} =new {0} ();", className));
                sb_1.Append("\n");
                sb_1.Append(string.Format("{0}  oldItem_{0} =new {0} ();", className));
                sb_1.Append("\n");
                foreach (var item in list)
                {
                    sb_1.Append(string.Format("newItem_{0}.", className) + item.ColumnName + string.Format("=oldItem_{0}.", className) + item.ColumnName + ";");
                    sb_1.Append("\n");

                }
                sb_1.Append("//-----2.oldModel赋值给newModel------");
                //
                StringBuilder sb_2 = new StringBuilder();
                sb_2.Append("//-----3.ID |值 对应Jason------");
                sb_2.Append("\n");
                sb_2.Append(string.Format("var  {0}_DTO=  {{", className));
                sb_2.Append("\n");

                for (int i = 0; i < list.Count; i++)
                {
                    var ColumnStr = string.Format("{0}:", ChangeToYinHao(list[i].ColumnName)) + "$('#aaaaa').val(),";

                    if (!string.IsNullOrEmpty(list[i].ColumnUI_ID))
                    {
                        ColumnStr = string.Format("{0}:", ChangeToYinHao(list[i].ColumnName)) + string.Format("$('#{0}').val(),", list[i].ColumnUI_ID);
                    }
                    if (i == list.Count - 1)
                    {
                        ColumnStr = ColumnStr.Substring(0, ColumnStr.Length - 1);
                    }
                    sb_2.Append(ColumnStr);
                    sb_2.Append("\n");
                }

                sb_2.Append("\n");
                sb_2.Append("};");
                sb_2.Append("\n");




                StringBuilder sb_3 = new StringBuilder();
                sb_3.Append("//-----4.ID|值转成普通Jason------");
                sb_3.Append("\n");
                sb_3.Append(string.Format("var  {0}_DTO=  {{", className));
                sb_3.Append("\n");

                for (int i = 0; i < list.Count; i++)
                {
                    var ColumnStr = string.Format("{0}:", ChangeToDanYinHao(list[i].ColumnName)) + "null,";
                    if (!string.IsNullOrEmpty((list[i].JasonDefaultValue)))
                    {
                        ColumnStr = string.Format("{0}:", ChangeToDanYinHao(list[i].ColumnName)) + string.Format("{0},", list[i].JasonDefaultValue);
                    }
                    if (i == list.Count - 1)
                    {
                        ColumnStr = ColumnStr.Substring(0, ColumnStr.Length - 1);
                    }
                    sb_3.Append(ColumnStr);
                    sb_3.Append("\n");
                }

                sb_3.Append("\n");
                sb_3.Append("};");
                sb_3.Append("\n");




                StringBuilder sb_4 = new StringBuilder();
                sb_4.Append("//----5.Jason赋值ID------");
                for (int i = 0; i < list.Count; i++)
                {
                    var ColumnStr = "$('#aaaaa').val(" + "data." + list[i].ColumnName + ");";
                    if (!string.IsNullOrEmpty(list[i].ColumnUI_ID))
                    {
                        ColumnStr = string.Format("$('#{0}').val(", list[i].ColumnUI_ID) + "data." + list[i].ColumnName + ");";
                    }

                    sb_4.Append(ColumnStr);
                    sb_4.Append("\n");
                }


                StringBuilder sb_5 = new StringBuilder();
                sb_5.Append("//----6.DataTable Colmns------");
                sb_5.Append("\n");
                sb_5.Append(" var columns = [");
                sb_5.Append("\n");
                for (int i = 0; i < list.Count; i++)
                {

                    sb_5.Append("{");
                    sb_5.Append("\n");

                    sb_5.Append(string.Format("data: {0},", ChangeToYinHao(list[i].ColumnName)));
                    sb_5.Append("\n");
                    sb_5.Append(string.Format("className:\"min-col-xs text-center\""));
                    sb_5.Append("\n");


                    if (i == list.Count - 1)
                    {
                        sb_5.Append("}");
                    }
                    else
                    {
                        sb_5.Append("},");
                    }
                    sb_5.Append("\n");

                }
                sb_5.Append("];");

                ///

                StringBuilder sb_7 = new StringBuilder();
                sb_7.Append("//\n");
                sb_7.Append("//----7.DataTable thead tfoot------");
                sb_7.Append("\n");
                sb_7.Append("<table class=\"table table-striped table-hover table-condensed nowrap\" id=\"js_user_datatable\">");
                sb_7.Append("\n");
                sb_7.Append("<thead>");
                sb_7.Append("\n");
                sb_7.Append("<tr>");
                sb_7.Append("\n");
                sb_7.Append("<th class=\"table-col-checkbox nosort\">");
                sb_7.Append("\n");
                sb_7.Append("<input type=\"checkbox\" class=\"js-checkbox-all\" />");
                sb_7.Append("\n");
                sb_7.Append("</th>");
                sb_7.Append("\n");
                sb_7.Append("<th class=\"table-col-seq nosort\">Seq</th>");
                sb_7.Append("\n");
                foreach (var item in list)
                {
                    sb_7.Append(string.Format("<th class=\"js-sort\" name=\"{0}\">{1}</th>", item.ColumnName, item.ColumnUI_DisplayName));
                    sb_7.Append("\n");
                }

                sb_7.Append("</tr>");
                sb_7.Append("\n");
                sb_7.Append("</thead>");
                sb_7.Append("\n");
                sb_7.Append("<tfoot>");
                sb_7.Append("\n");
                sb_7.Append("<tr>");
                sb_7.Append("\n");
                sb_7.Append("<th class=\"table-col-checkbox nosort\"></th>");
                sb_7.Append("\n");
                sb_7.Append("<th class=\"table-col-seq nosort\">Seq</th>");
                sb_7.Append("\n");
                foreach (var item in list)
                {
                    sb_7.Append(string.Format("<th>{0}</th>", item.ColumnUI_DisplayName));
                    sb_7.Append("\n");
                }

                sb_7.Append("\n");
                sb_7.Append("</tr>");
                sb_7.Append("\n");
                sb_7.Append("</tfoot>");
                sb_7.Append("\n");
                sb_7.Append("</table>");
                sb_7.Append("\n");
                sb_7.ToString();


                StringBuilder sb_9 = new StringBuilder();
                sb_9.AppendLine("" + className + "DTO dto = " + GetResponeNameRule(className) + "Repository.GetAll().Select(".ToString());
                sb_9.AppendLine("               m => new " + className + "DTO".ToString());
                sb_9.AppendLine("               {".ToString());

                for (int i = 0; i < list.Count; i++)
                {

                    if (i == list.Count - 1)
                    {
                        sb_9.AppendLine("                   " + list[i].ColumnName + " = m." + list[i].ColumnName + "".ToString());
                    }
                    else
                    {
                        sb_9.AppendLine("                   " + list[i].ColumnName + " = m." + list[i].ColumnName + ",".ToString());
                    }
                }
                sb_9.AppendLine("               }".ToString());
                sb_9.AppendLine("                ).ToList().FirstOrDefault();".ToString());


                StringBuilder sb_10 = new StringBuilder();
                sb_10.AppendLine("" + className + ".ToList().Select(".ToString());
                sb_10.AppendLine("               m => new ".ToString());
                sb_10.AppendLine("               {".ToString());
                for (int i = 0; i < list.Count; i++)
                {

                    if (i == list.Count - 1)
                    {
                        sb_10.AppendLine("                   " + list[i].ColumnName + " = m." + list[i].ColumnName + "".ToString());
                    }
                    else
                    {
                        sb_10.AppendLine("                   " + list[i].ColumnName + " = m." + list[i].ColumnName + ",".ToString());
                    }
                }
                sb_10.AppendLine("               }".ToString());
                sb_10.AppendLine("                ).ToList().ToJson().Dump();".ToString());
                sb_10.ToString();


                //var bbb= this.txt_sbname.Text.Trim();



                sb_ALL.Append("//赋值：生成-1");
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_10.ToString());
                sb_ALL.Append("\n");


                sb_ALL.Append("//赋值：生成0");
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_9.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append("//赋值：生成1");
                sb_ALL.Append("\n");
                sb_ALL.Append(sb.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append("//old赋值给new生成2");
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_1.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_2.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_3.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_4.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_5.ToString());
                sb_ALL.Append("\n");
                sb_ALL.Append(sb_7.ToString());

                var sb_8 = DataTable_Js(list);
                sb_ALL.Append(sb_8.ToString());


                var sb_92 = DymiciStr(list);
                sb_ALL.Append(sb_92.ToString());
                //ConstConstants.modelClassDataTable.TableName = "11";
                ConstConstants.modelClassDataTable = DataTableExtensions.ToDataTable<ModelClass>(list);
                ExcelExtensions.ExportExcelWithAspose(ConstConstants.modelClassDataTable, ConstConstants.Const_ModelClass);


            }
            return sb_ALL.ToString();
        }

        public string GeneratedModelClassByListSingle(List<ModelClass> list)
        {


            StringBuilder sb = new StringBuilder();
            if (list.Count != 0)
            {
                var className = list[0].TableName.Trim();
                sb.Append(string.Format("public class {0} ", className));
                sb.Insert(0, "");
                sb.Append("\n");
                sb.Append("{");
                sb.Append("\n");
                foreach (var item in list)
                {
                    var type = item.DataType.ToString().ToLower();
                    switch (type)
                    {
                        default:
                            type = "string";
                            break;
                        case "nvarchar":
                        case "varchar":
                            type = "string";
                            break;
                        case "uniqueidentifier":
                            type = "Guid";
                            break;
                        case "date":
                        case "datetime":
                            type = "DateTime";
                            break;
                        case "int":
                            type = "Int";
                            break;
                    }

                    sb.Append(string.Format(" public {0} {1}", type, item.ColumnName) + " { get; set; }");
                    sb.Append("\n");
                }
                sb.Append("\n");
                sb.Append("}");

            }
            return sb.ToString();

        }

        public string GenerateJasonFunction(List<ModelClass> list)
        {
            SettingVM vm = allSettings(list);

            #region Add
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//" + vm.TableNameToLower + " Add".ToString());
            sb.AppendLine("function set_" + vm.TableNameToLower + "_model() {".ToString());
            sb.AppendLine("            var " + vm.TableName + "_VM = {".ToString());
            //sb.AppendLine("                \"Contract_PaymentOneTime_UID\": GetNewGuid(),".ToString());

            for (int i = 0; i < list.Count; i++)
            {

                if (i == list.Count - 1)
                {
                    sb.AppendLine("                \"" + list[i].ColumnName + "\": $('#" + list[i].ColumnUI_ID + "').val()".ToString());
                }
                else
                {
                    sb.AppendLine("                \"" + list[i].ColumnName + "\": $('#" + list[i].ColumnUI_ID + "').val(),".ToString());
                }
            }

            sb.AppendLine("            };".ToString());
            sb.AppendLine("            return " + vm.TableName + "_VM;".ToString());
            sb.AppendLine("        }".ToString());
            #endregion

            #region Eidt
            sb.AppendLine("//" + vm.TableNameToLower + " Eidt".ToString());

            sb.AppendLine("function edit_" + vm.TableNameToLower + "_model(uid) {".ToString());
            sb.AppendLine("            for (var i = 0; i < " + vm.TableName + "JasonArray.length; i++) {".ToString());
            sb.AppendLine("                if (" + vm.TableName + "JasonArray[i]." + vm.PKUID + " == uid) {".ToString());

            //sb.AppendLine("                    ContractApplicant.One_Time[i].Payment_Timing = $('#js_select_payment_timing').val();".ToString());

            for (int i = 0; i < list.Count; i++)
            {


                sb.AppendLine("                    " + vm.TableName + "JasonArray[i]." + list[i].ColumnName + " = $('#" + list[i].ColumnUI_ID + "').val();".ToString());

            }


            sb.AppendLine("                }".ToString());
            sb.AppendLine("            }".ToString());
            sb.AppendLine("            bind_" + vm.TableNameToLower + "_model();".ToString());
            sb.AppendLine("        }".ToString());
            sb.ToString();
            #endregion

            #region Delete
            sb.AppendLine("//" + vm.TableNameToLower + " Delete".ToString());
            sb.AppendLine("function del_" + vm.TableNameToLower + "_model(uid) {".ToString());
            sb.AppendLine("            for (var i = 0; i < " + vm.TableName + "JasonArray.length; i++) {".ToString());
            sb.AppendLine("                if (" + vm.TableName + "JasonArray[i]." + vm.PKUID + " == uid) {".ToString());
            sb.AppendLine("                    " + vm.TableName + ".splice(i, 1);".ToString());
            sb.AppendLine("                }".ToString());
            sb.AppendLine("            }".ToString());
            sb.AppendLine("            bind_" + vm.TableNameToLower + "_model();".ToString());
            sb.AppendLine("        }".ToString());
            sb.ToString();
            #endregion

            #region Bind
            sb.AppendLine("//" + vm.TableNameToLower + " Bind".ToString());
            sb.AppendLine("function bind_" + vm.TableNameToLower + "_model(uid) {".ToString());
            sb.AppendLine("            for (var i = 0; i < " + vm.TableName + "JasonArray.length; i++) {".ToString());
            sb.AppendLine("                if (" + vm.TableName + "JasonArray[i]." + vm.PKUID + " == uid) {".ToString());
            //sb.AppendLine("                    $('#js_select_payment_timing').val(ContractApplicant.One_Time[i].Payment_Timing);".ToString());
            for (int i = 0; i < list.Count; i++)
            {
                sb.AppendLine("                    $('#" + list[i].ColumnUI_ID + "').val(" + vm.TableName + "JasonArray[i]." + list[i].ColumnName + ");".ToString());


            }
            sb.AppendLine("            }".ToString());
            sb.AppendLine("        }".ToString());
            sb.AppendLine("        }".ToString());
            sb.ToString();
            #endregion


            #region Valid
            sb.AppendLine("function set_empty_data() {".ToString());

            var list_have = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].DataType.ToLower() == "uniqueidentifier")
                {
                    sb.AppendLine("            //uniqueidentifier".ToString());
                    sb.AppendLine("            var " + list[i].ColumnName + " = $('#" + list[i].ColumnUI_ID + "').val();".ToString());
                    sb.AppendLine("            if (" + list[i].ColumnName + " == null || " + list[i].ColumnName + " == '') {".ToString());
                    sb.AppendLine("                " + list[i].ColumnName + " = EmptyGuid();".ToString());
                    sb.AppendLine("            }".ToString());
                    sb.AppendLine("        ".ToString());
                    list_have.Add(list[i].ColumnName);
                }

                if (list[i].DataType.ToLower() == "date")
                {
                    sb.AppendLine("            //datetime".ToString());
                    sb.AppendLine("            var " + list[i].ColumnName + " = $('#" + list[i].ColumnUI_ID + "').val();".ToString());
                    sb.AppendLine("            if (" + list[i].ColumnName + " == null || " + list[i].ColumnName + " == '') {".ToString());
                    sb.AppendLine("                " + list[i].ColumnName + " = EmptyDate();".ToString());
                    sb.AppendLine("            }".ToString());
                    sb.AppendLine("        ".ToString());
                    list_have.Add(list[i].ColumnName);
                }

                if (list[i].DataType.ToLower() == "int")
                {
                    sb.AppendLine("            //number".ToString());
                    sb.AppendLine("            var " + list[i].ColumnName + " = $('#" + list[i].ColumnUI_ID + "').val();".ToString());
                    sb.AppendLine("            if (" + list[i].ColumnName + " == null || " + list[i].ColumnName + " == '') {".ToString());
                    sb.AppendLine("                " + list[i].ColumnName + " = EmptyNumber();".ToString());
                    sb.AppendLine("            }".ToString());
                    sb.AppendLine("        ".ToString());
                    list_have.Add(list[i].ColumnName);
                }

                if (list[i].DataType.ToLower() == "bit")
                {
                    sb.AppendLine("            //Bool".ToString());
                    sb.AppendLine("            var " + list[i].ColumnName + " = $('#" + list[i].ColumnUI_ID + "').val();".ToString());
                    sb.AppendLine("            if (" + list[i].ColumnName + " == null || " + list[i].ColumnName + " == '') {".ToString());
                    sb.AppendLine("                " + list[i].ColumnName + " = EmptyBool();".ToString());
                    sb.AppendLine("            }".ToString());
                    sb.AppendLine("        ".ToString());
                    list_have.Add(list[i].ColumnName);
                }

            }

            sb.AppendLine("var  " + vm.TableName + "_DTO=  {".ToString());

            for (int i = 0; i < list.Count; i++)
            {

                if (i == list.Count - 1)
                {

                    if (list_have.Contains(list[i].ColumnName))
                    {

                        sb.AppendLine("\"" + list[i].ColumnName + "\":" + list[i].ColumnName + "".ToString());
                    }
                    else
                    {
                        sb.AppendLine("\"" + list[i].ColumnName + "\":$('#" + list[i].ColumnUI_ID + "').val()".ToString());
                    }
                }
                else
                {
                    if (list_have.Contains(list[i].ColumnName))
                    {
                        sb.AppendLine("\"" + list[i].ColumnName + "\":" + list[i].ColumnName + ",".ToString());
                    }
                    else
                    {
                        sb.AppendLine("\"" + list[i].ColumnName + "\":$('#" + list[i].ColumnUI_ID + "').val(),".ToString());

                    }


                }
            }

            sb.AppendLine("            }".ToString());
            sb.AppendLine("}".ToString());

            #endregion

            #region C# Valid   Is_Identity

            sb.AppendLine("      //C# Validate".ToString());

            sb.AppendLine("public string " + vm.TableName + "_Validate(" + vm.TableName + " vm)".ToString());
            sb.AppendLine("        {".ToString());
            sb.AppendLine("            string errorMessage = string.Empty;".ToString());

            for (int i = 0; i < list.Count; i++)
            {
                if ((list[i].Is_Null.ToString().ToLower() == "false") & (list[i].ColumnType.ToLower() == "string"))//不为空
                {
                    sb.AppendLine("            if (string.IsNullOrWhiteSpace(vm." + list[i].ColumnName + "))".ToString());
                    sb.AppendLine("            {".ToString());
                    sb.AppendLine("                errorMessage = errorMessage +\"" + list[i].ColumnName + " is Required.\"+ \"<br/>\";".ToString());
                    sb.AppendLine("            }".ToString());
                }
                if ((list[i].Is_Null.ToString().ToLower() == "false") & (list[i].ColumnType.ToLower() == "guid"))//不为空
                {
                    sb.AppendLine("if (vm." + list[i].ColumnName + "==Guid.Empty)".ToString());
                    sb.AppendLine("            {".ToString());
                    sb.AppendLine("                errorMessage = errorMessage +\"" + list[i].ColumnName + " is Required.\"+ \"<br/>\";".ToString());
                    sb.AppendLine("            }".ToString());
                }
                if ((list[i].Is_Null.ToString().ToLower() == "false") & (list[i].ColumnType.ToLower() == "bit"))//不为空
                {
                    sb.AppendLine("if (vm." + list[i].ColumnName + "==true)".ToString());
                    sb.AppendLine("            {".ToString());
                    sb.AppendLine("                errorMessage = errorMessage +\"" + list[i].ColumnName + " is Required.\"+ \"<br/>\";".ToString());
                    sb.AppendLine("            }".ToString());
                }
                if ((list[i].Is_Null.ToString().ToLower() == "false") & ((list[i].ColumnType.ToLower() == "decimal") || (list[i].ColumnType.ToLower() == "int")))//不为空
                {
                    sb.AppendLine("if (vm." + list[i].ColumnName + "==0)".ToString());
                    sb.AppendLine("            {".ToString());
                    sb.AppendLine("                errorMessage = errorMessage +\"" + list[i].ColumnName + " is Required.\"+ \"<br/>\";".ToString());
                    sb.AppendLine("            }".ToString());
                }
            }
            sb.AppendLine("            return errorMessage;".ToString());
            sb.AppendLine("        ".ToString());
            sb.AppendLine("        }".ToString());
            sb.ToString();

            #endregion


            return sb.ToString();
        }

        public SettingVM allSettings(List<ModelClass> list)
        {
            SettingVM vm = new SettingVM();
            vm.list = list;
            var model = list.Where(m => m.Is_Identity == "True").FirstOrDefault();
            if (model == null)
            {
                model = list.FirstOrDefault();
            }
            vm.TableName = model.TableName;
            vm.TableNameToLower = model.TableName.ToLower();
            vm.PKUID = model.ColumnName;
            return vm;
        }


        public string GeneratedModelClass(string content)
        {

            var list = GetModelClassList(content);
            return GeneratedModelClassByList(list);
        }

        public string ChangeToYinHao(string str)
        {
            string re = string.Empty;
            re = "\"" + str + "\"";
            return re;
        }

        public string ChangeToDanYinHao(string str)
        {
            string re = string.Empty;
            re = "'" + str + "'";
            return re;
        }

        public string DataTable_Js(List<ModelClass> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("//闭包用法".ToString().ToStringToN());
            sb.Append("var SupplierDocCheckSetting = (function () {".ToString().ToStringToN());
            sb.Append("var needBuildCriteria = false;".ToString().ToStringToN());
            sb.Append("var urls = {".ToString().ToStringToN());
            sb.Append("Method1: '@Url.Action(\"Method1\", \"ContractManagement\")',".ToString().ToStringToN());
            sb.Append("Method2: '@Url.Action(\"Method2\", \"ContractManagement\")',".ToString().ToStringToN());
            sb.Append("Method3: '@Url.Action(\"Method3\", \"ContractManagement\")',".ToString().ToStringToN());
            sb.Append("};".ToString().ToStringToN());
            sb.Append("var columns = [".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("createdCell: function (td, cellData, rowData, row, col) {".ToString().ToStringToN());
            sb.Append("$(td).html('<input type=\"checkbox\" name=\"cktrans\" class=\"js-checkbox-item\" value=\"' + rowData.SupplierDocType_D_UID + '\" >').addClass('table-col-checkbox');".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());
            sb.Append("className: \"text-center\"".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());
            sb.Append("{".ToString().ToStringToN());
            sb.Append("createdCell: function (td, cellData, rowData, row, col) {".ToString().ToStringToN());
            sb.Append("$(td).html('<a tabindex=\"0\" class=\"btn btn-primary btn-xs\" rel=\"action-popover\" role=\"button\"><i class=\"fa fa-reorder\"></i></a>' +".ToString().ToStringToN());
            sb.Append("'<div class=\"hidden popover-content\">' +".ToString().ToStringToN());
            sb.Append("'<button type=\"button\" class=\"btn btn-primary btn-xs format-button-width js-grid-view\" data-id=\"' + rowData.SupplierDocType_D_UID + '\" muid=\"' +  rowData.SupplierDocType_M_UID + '\" >View</button>' + '<br>' +".ToString().ToStringToN());
            sb.Append("'<button type=\"button\" class=\"btn btn-primary btn-xs format-button-width js-grid-edit\" data-id=\"' + rowData.SupplierDocType_D_UID + '\" muid=\"' +  rowData.SupplierDocType_M_UID + '\">Edit</button>' + '<br>' +".ToString().ToStringToN());
            sb.Append("'<button type=\"button\" class=\"btn btn-primary btn-xs format-button-width js-grid-delete\" data-id=\"' + rowData.SupplierDocType_D_UID + '\">Delete</button>' +".ToString().ToStringToN());
            sb.Append("'</div>');".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());
            sb.Append("className: \"text-center min-col-xs\"".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append(",".ToString().ToStringToN());

            sb.Append("{".ToString().ToStringToN());
            sb.Append("data: null,".ToString().ToStringToN());
            sb.Append("className: \"table-col-seq min-col-xs\"".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());

            foreach (var item in list)
            {
                sb.Append("{".ToString().ToStringToN());
                sb.Append("data: \"" + item.ColumnName + "\",".ToString().ToStringToN());
                sb.Append("className: \"min-col-xs\"".ToString().ToStringToN());
                sb.Append("},".ToString().ToStringToN());
            }


            //sb.Append("{".ToString().ToStringToN());
            //sb.Append("data: \"RegionName\",".ToString().ToStringToN());
            //sb.Append("className: \"min-col-xs\"".ToString().ToStringToN());
            //sb.Append("},".ToString().ToStringToN());
            //sb.Append("{".ToString().ToStringToN());
            //sb.Append("data: \"Doc\",".ToString().ToStringToN());
            //sb.Append("className: \"min-col-xs\"".ToString().ToStringToN());
            //sb.Append("}, {".ToString().ToStringToN());
            //sb.Append("data: \"DocAbbreviation\",".ToString().ToStringToN());
            //sb.Append("className: \"min-col-xs\"".ToString().ToStringToN());
            //sb.Append("}".ToString().ToStringToN());


            sb.Append("];".ToString().ToStringToN());
            sb.Append("var _getParams = function () {".ToString().ToStringToN());
            sb.Append("return $('#js_form_query').serialize().replace(/\\+/g, \" \");".ToString().ToStringToN());
            sb.Append("};".ToString().ToStringToN());
            sb.Append("var _queryCondition = function (firstLoad, buildCriteria) {".ToString().ToStringToN());
            sb.Append("var config = {".ToString().ToStringToN());
            sb.Append("pageId: \"#page\",".ToString().ToStringToN());
            sb.Append("tableId: \"#js_checkdocsetting_datatable\",".ToString().ToStringToN());
            sb.Append("remoteUrl: urls.QuerySupplierDocCheckSetting,".ToString().ToStringToN());
            sb.Append("searchParams: _getParams(),".ToString().ToStringToN());
            sb.Append("tableOptions: {".ToString().ToStringToN());
            sb.Append("//scrollX: true,".ToString().ToStringToN());
            sb.Append("//scrollCollapse: false,".ToString().ToStringToN());
            sb.Append("//autoWidth: true,".ToString().ToStringToN());
            sb.Append("columns: columns".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("};".ToString().ToStringToN());

            sb.Append("if (!firstLoad) {".ToString().ToStringToN());
            sb.Append("$('#page').page('destroy');".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("if (needBuildCriteria) {".ToString().ToStringToN());
            sb.Append("SPP.Utility.Criteria.Build();".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("SPP.Utility.Pages.Set(config);".ToString().ToStringToN());
            sb.Append("};".ToString().ToStringToN());
            sb.Append("return {".ToString().ToStringToN());
            sb.Append("urls: urls,".ToString().ToStringToN());
            sb.Append("Init: function () {".ToString().ToStringToN());
            sb.Append("SPP.Utility.Criteria.Init();".ToString().ToStringToN());
            sb.Append("_queryCondition(true);".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());
            sb.Append("QueryUserBUs: function (isSearchBtn) {".ToString().ToStringToN());
            sb.Append("needBuildCriteria = (isSearchBtn === true ? true : needBuildCriteria);".ToString().ToStringToN());
            sb.Append("_queryUsers(false);".ToString().ToStringToN());
            sb.Append("},".ToString().ToStringToN());
            sb.Append("Viewcolumns: columns".ToString().ToStringToN());
            sb.Append("}".ToString().ToStringToN());
            sb.Append("})();".ToString().ToStringToN());
            sb.ToString();
            return sb.ToString();
        }


        public string DymiciStr(List<ModelClass> list)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DynamicParameters sParam = new DynamicParameters();".ToString());
            foreach (var item in list)
            {
                sb.AppendLine("            sParam.Add(\""+item.ColumnName+"\", request."+item.ColumnName+");".ToString());
            }


            return sb.ToString();

        }

        public void test()
        {
            List<string> list = new List<string>();
            foreach (var item in list)
            {
                item.ToString();
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {

                }
                if (i > 0)
                {
                    


                }
            }

            List<string> result = new List<string>();
           list.ForEach(
               (s) =>
               {
                   if (!string.IsNullOrEmpty(s))
                   {
                       list.Add(s);
                   }
               }
                );

        }

        #endregion


    }
}
