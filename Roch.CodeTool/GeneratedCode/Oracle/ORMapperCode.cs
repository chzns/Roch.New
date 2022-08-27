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

using Roch.Framework;
using Roch.DomainModel;

namespace Roch.CodeTool.GeneratedCode.Oracle
{
    public class ORMapperCode : BaseCode
    {
        public ORMapperCode()
            : base()
        {
            m_TemplateType = TemplateType.Mapper;
        }

        public override string GeneratedCode()
        {
            StringBuilder columnTemplate = new StringBuilder(base.GeneratedCode());

            StringBuilder sbFields = new StringBuilder();               //表字段            
            StringBuilder sbRowToClass = new StringBuilder();           //表格行到实体
            StringBuilder sbInsertFieldFormat = new StringBuilder();    //添加实体格式
            StringBuilder sbInsertFieldValue = new StringBuilder();     //添加实体值
            StringBuilder sbUpdateFieldFormat = new StringBuilder();    //更新实体格式
            StringBuilder sbUpdateFieldValue = new StringBuilder();     //更新实体值

            string lowerClassName = ConvertHelper.ToLower(m_ConfigInfo.ClassName);
            int insertIndex = 0;
            int updateIndex = 0;

            foreach (ColumnModel column in m_CurrentColumnModels)
            {
                string field = ConvertHelper.ToOracleField(column.Name);
                string property = string.Format("{0}.{1}", lowerClassName, ConvertHelper.ToTitleCase(column.Name));
                string propertyValue = GetOracleProcessStringByType(column.TypeName, property,column.Length,column.Precision);

                sbFields.AppendFormat("{0}, ", field);
                sbInsertFieldFormat.AppendFormat("{0}, ", GetOracleFormatByType(column.TypeName, insertIndex,column.Precision));
                sbInsertFieldValue.AppendFormat("{0}, ", propertyValue);

                sbRowToClass.AppendLine(string.Format("\t{0} {1} = {2}(row, \"{3}\");", Tab, property,GetOraclePropertyByType (column.TypeName,column.Length,column.Precision,column.Scale), column.Name));

                if (m_ConfigInfo.PK != column.Name)
                {
                    sbUpdateFieldFormat.AppendFormat("{0} = {1}, ", field, GetOracleFormatByType(column.TypeName, updateIndex,column.Precision));
                    sbUpdateFieldValue.AppendFormat("{0}, ", propertyValue);

                    updateIndex++;
                }

                insertIndex++;
            }

            if (sbFields.Length > 0)
            {
                sbFields = sbFields.Remove(sbFields.Length - 2, 2);
            }

            if (sbInsertFieldFormat.Length > 0)
            {
                sbInsertFieldFormat = sbInsertFieldFormat.Remove(sbInsertFieldFormat.Length - 2, 2);
            }

            if (sbInsertFieldValue.Length > 0)
            {
                sbInsertFieldValue = sbInsertFieldValue.Remove(sbInsertFieldValue.Length - 2, 2);
            }

            if (sbUpdateFieldFormat.Length > 0)
            {
                sbUpdateFieldFormat = sbUpdateFieldFormat.Remove(sbUpdateFieldFormat.Length - 2, 2);
            }

            if (sbUpdateFieldValue.Length > 0)
            {
                sbUpdateFieldValue = sbUpdateFieldValue.Remove(sbUpdateFieldValue.Length - 2, 2);
            }

            //替换表名称$TableName$
            columnTemplate.Replace("$TableName$", ConvertHelper.ToOracleField(m_ConfigInfo.TableName));
            //替换表名称$PageTableName$
            columnTemplate.Replace("$PageTableName$", m_ConfigInfo.TableName);
            //替换表主键$PagePK$
            columnTemplate.Replace("$PagePK$", m_ConfigInfo.PK);
            //替换主键类型$PKType$
            columnTemplate.Replace("$PKType$", m_ConfigInfo.PKType);
            //替换表字段$Fields$
            columnTemplate.Replace("$Fields$", sbFields.ToString());
            //替换表主键$PK$
            columnTemplate.Replace("$PK$", ConvertHelper.ToOracleField(m_ConfigInfo.PK));
            //替换表处理主键的$PKBegin$          
            columnTemplate.Replace("$PKBegin$", GetOraclePKBegin(m_ConfigInfo.PKType, m_ConfigInfo.PKLength));
            //替换表处理主键的$PkEnd$
            columnTemplate.Replace("$PkEnd$", GetOraclePKEnd(m_ConfigInfo.PKType, m_ConfigInfo.PKLength));
            //替换表主键属性$PKProperty$
            columnTemplate.Replace("$PKProperty$", ConvertHelper.ToTitleCase(m_ConfigInfo.PK));
            //替换表格行到实体$DataRowToClassName$
            columnTemplate.Replace("$DataRowToClassName$", RemoveFirstTab(RemoveEndRow(sbRowToClass.ToString()), 5));
            //替换添加实体格式$InsertFieldsFormat$
            columnTemplate.Replace("$InsertFieldsFormat$", sbInsertFieldFormat.ToString());
            //替换添加实体值$InsertFieldsValue$
            columnTemplate.Replace("$InsertFieldsValue$", sbInsertFieldValue.ToString());
            //替换实体属性个数$FieldCount$
            columnTemplate.Replace("$FieldCount$", (m_CurrentColumnModels.Count - 1).ToString());
            //替换更新实体格式$UpdateFieldFormat$
            columnTemplate.Replace("$UpdateFieldFormat$", sbUpdateFieldFormat.ToString());
            //替换更新实体值$UpdateFieldValue$
            columnTemplate.Replace("$UpdateFieldValue$", sbUpdateFieldValue.ToString());

            return columnTemplate.ToString();
        }
    }
}
