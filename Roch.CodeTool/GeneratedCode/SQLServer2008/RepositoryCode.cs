using System;
using System.Collections.Generic;
using System.Text;

using Roch.Framework;
using Roch.DomainModel;


namespace Roch.CodeTool.GeneratedCode.SQLServer2008
{
    public class RepositoryCode : BaseCode
    {

        public RepositoryCode()
            : base()
        {
            m_TemplateType = TemplateType.Repository;
        }


        public string GetWords(string str)
        {
            str = str.Replace("_", "");
            return str.Replace(" ", "");

        }

        public string GetPkWords(string str)
        {
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            return str.Replace(" ", "");
        }

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());
            //显示表名带有 【】 符号
            columnTemplate.Replace("$TableName$", ConvertHelper.ToField(m_ConfigInfo.TableName));
            //直接显示表名
            columnTemplate.Replace("$PageTableName$", m_ConfigInfo.TableName);
            //去除带有-符号的表名
            columnTemplate.Replace("$SpaceTableName$", GetWords(m_ConfigInfo.TableName));
            //替换表主键$PK$
            columnTemplate.Replace("$PK$", GetPkWords(ConvertHelper.ToField(m_ConfigInfo.PK)));

            //DTO生成
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbProperty = new StringBuilder();

            foreach (ColumnModel column in m_CurrentColumnModels)
            {
                string typeName = DBTypeUtilily.DBTypeToCS(column.TypeName);

                string propertyName = column.Name;

                if (!m_ConfigInfo.IsUsePK && m_ConfigInfo.PK == propertyName)
                {
                    continue;
                }

                propertyName = ConvertHelper.ToTitleCase(propertyName);

                //sbField.AppendLine(string.Format("\tprivate {0} m_{1};", typeName, propertyName));

                sbProperty.AppendLine();
                sbProperty.AppendLine("\t/// <summary>");
                sbProperty.AppendLine(string.Format("\t/// {0}", column.Description));
                sbProperty.AppendLine("\t/// </summary>");



                #region 修改属性方法
                sbProperty.AppendLine(string.Format("\t public {0} {1}", typeName, propertyName) + " { get; set; }");
                //sbProperty.AppendLine("\t{ get ;set;}");
        
                #endregion


                //#region 修改属性方法2017-02-27注释
                //sbProperty.AppendLine(string.Format("\tpublic {0} {1}", typeName, propertyName));
                //sbProperty.AppendLine("\t{");
                //sbProperty.AppendLine("\t get ;set;");
                //sbProperty.AppendLine("\t}"); 
                //#endregion


                //sbProperty.AppendLine(string.Format("\t{0}get ", Tab) + "{ " + string.Format("return m_{0};", propertyName) + " }");
                //sbProperty.AppendLine(string.Format("\t{0}set ", Tab) + "{ " + string.Format("m_{0} = value;", propertyName) + " }");
            }

            //替换类字段$Field$
            columnTemplate.Replace("$Field$", RemoveFirstTab(RemoveEndRow(sbField.ToString())));
            //替换类字段$Property$
            columnTemplate.Replace("$Property$", RemoveFirstTab(RemoveFirstRow(RemoveEndRow(sbProperty.ToString()))));
         
            return columnTemplate.ToString();
        }


    }


}
