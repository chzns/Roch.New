//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :MapperparameterCode
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.Text;

using Roch.DomainModel;
using Roch.Framework;

namespace Roch.CodeTool.GeneratedCode.SQLServer
{
    /// <summary>
    /// 生成数据参数映射代码
    /// </summary>
    public class MapperparameterCode : BaseCode
    {
        public MapperparameterCode()
            : base()
        {
            m_TemplateType = TemplateType.MapperParameter;
        }        

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());

            StringBuilder sbFields = new StringBuilder();               //表字段            
            StringBuilder sbRowToClass = new StringBuilder();           //表格行到实体
            StringBuilder sbInsertFieldFormat = new StringBuilder();    //添加实体格式
            StringBuilder sbUpdateFieldFormat = new StringBuilder();    //更新实体格式
            StringBuilder sbParameters = new StringBuilder();           //参数

            string lowerClassName = ConvertHelper.ToLower(m_ConfigInfo.ClassName);

            foreach (ColumnModel column in m_CurrentColumnModels)
            {
                string field = ConvertHelper.ToField(column.Name);
                string property = string.Format("{0}.{1}", lowerClassName, ConvertHelper.ToTitleCase(column.Name));
                string propertyValue = GetProcessStringByType(column.TypeName, property);

                sbFields.AppendFormat("{0}, ", field);
                sbInsertFieldFormat.AppendFormat("@{0}, ", column.Name);

                sbRowToClass.AppendLine(string.Format("\t{0} {1} = {2}(row, \"{3}\");", Tab, property, GetPropertyByType(column.TypeName), column.Name));


                sbParameters.AppendLine(string.Format("\t{0} parameters.Add(new SqlParameter(\"@{1}\", {2}.{3}));", Tab, column.Name, lowerClassName, ConvertHelper.ToTitleCase(column.Name)));

                if (m_ConfigInfo.PK != column.Name)
                {
                    sbUpdateFieldFormat.AppendFormat("{0} = @{1}, ", field, column.Name);
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

            //替换表名称$TableName$
            columnTemplate.Replace("$TableName$", ConvertHelper.ToField(m_ConfigInfo.TableName));
            //替换表名称$PageTableName$
            columnTemplate.Replace("$PageTableName$", m_ConfigInfo.TableName);
            //替换表主键$PagePK$
            columnTemplate.Replace("$PagePK$", m_ConfigInfo.PK);
            //替换主键类型$PKType$
            columnTemplate.Replace("$PKType$", m_ConfigInfo.PKType);
            //替换表字段$Fields$
            columnTemplate.Replace("$Fields$", sbFields.ToString());
            //替换表主键$PK$
            columnTemplate.Replace("$PK$", ConvertHelper.ToField(m_ConfigInfo.PK));
            //替换表主键参数$PKParameter$
            columnTemplate.Replace("$PKParameter$", m_ConfigInfo.PK);
            //替换表格行到实体$DataRowToClassName$
            columnTemplate.Replace("$DataRowToClassName$", RemoveFirstTab(RemoveEndRow(sbRowToClass.ToString()), 5));
            //替换添加实体格式$InsertFieldsFormat$
            columnTemplate.Replace("$InsertFieldsFormat$", sbInsertFieldFormat.ToString());
            //替换更新实体格式$UpdateFieldFormat$
            columnTemplate.Replace("$UpdateFieldFormat$", sbUpdateFieldFormat.ToString());
            //替换实体参数$Parameters$
            columnTemplate.Replace("$Parameters$", RemoveFirstTab(RemoveEndRow(sbParameters.ToString()), 5));

            return columnTemplate.ToString();
        }
    }
}
