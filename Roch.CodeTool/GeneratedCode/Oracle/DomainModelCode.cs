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

using Roch.DomainModel;
using Roch.Framework;
using Roch.Database;

namespace Roch.CodeTool.GeneratedCode.Oracle
{
    public class DomainModelCode : BaseCode
    {
        public DomainModelCode()
            :base()
        {
            m_TemplateType = TemplateType.Model;
        }

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbProperty = new StringBuilder();

            foreach (ColumnModel column in m_CurrentColumnModels)
            {
                string typeName = DBTypeUtilily.OracleDBTypeToCS(column.TypeName, column.Length, column.Precision, column.Scale);

                string propertyName = column.Name;

                if (!m_ConfigInfo.IsUsePK && m_ConfigInfo.PK == propertyName)
                {
                    continue;
                }

                propertyName = ConvertHelper.ToTitleCase(propertyName);

                sbField.AppendLine(string.Format("\tprivate {0} m_{1};", typeName, propertyName));

                sbProperty.AppendLine();
                sbProperty.AppendLine("\t/// <summary>");
                sbProperty.AppendLine(string.Format("\t/// {0}", column.Description));
                sbProperty.AppendLine("\t/// </summary>");
                sbProperty.AppendLine(string.Format("\t public {0} {1}", typeName, propertyName));
                sbProperty.AppendLine("\t{");
                sbProperty.AppendLine(string.Format("\t{0}get ", Tab) + "{ " + string.Format("return m_{0};", propertyName) + " }");
                sbProperty.AppendLine(string.Format("\t{0}set ", Tab) + "{ " + string.Format("m_{0} = value;", propertyName) + " }");
                sbProperty.AppendLine("\t}");
            }

            //替换类字段$Field$
            columnTemplate.Replace("$Field$", RemoveFirstTab(RemoveEndRow(sbField.ToString())));
            //替换类字段$Property$
            columnTemplate.Replace("$Property$", RemoveFirstTab(RemoveFirstRow(RemoveEndRow(sbProperty.ToString()))));

            return columnTemplate.ToString();
        }
    }
}
