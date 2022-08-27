//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :CodeMain
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

using Roch.DomainModel;
using Roch.Framework;
using Roch.Framework.Configuration;
using Roch.CodeTool.GeneratedCode;
using Roch.CodeTool.GeneratedCode.Oracle;
using Roch.Database;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
using System.Data;



namespace Roch.CodeTool
{
    public partial class CodeMain
    {
        #region 原来方法
        private void btnGenerated_Click(object sender, EventArgs e)
        {
            m_ConfigInfo.ClassName = ConvertHelper.ToTitleCase(txtClassName.Text);
            m_ConfigInfo.ClassDescript = txtDescript.Text;
     
            m_ConfigInfo.PK = txtPK.Text;


            if (m_CurrentColumnModels.Count == 0)
            {
                return;
            }

            //m_ConfigInfo 在构造函数中初始化
            //m_CurrentColumnModels 在选择树型节点时初始化
            GenerateCodeContent();
        }

        /// <summary>
        /// 生成代码内容
        /// </summary>
        /// <param name="configInfo"></param>
        private void GenerateCodeContent()
        {
            GeneratedDomainModel();
            GeneratedDomainFace();
            GeneratedORMapper();
            GeneratedORParameterMapper();
            GeneratedSQLCode();
            GeneratedUI();
            GenerateSpp();
            GenerateModelClass();
        }

        /// <summary>
        /// 生成Spp代码
        /// </summary>


        /// <summary>
        /// 生成Model组合代码
        /// </summary>


        /// <summary>
        /// 生成实体内容
        /// </summary>
        private void GeneratedDomainModel()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Model, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //txtDomainModel.Text = generateCode.GeneratedCode();
            }
            catch 
            {

            }
        }

        /// <summary>
        /// 生成外观内容
        /// </summary>
        private void GeneratedDomainFace()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Face, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //txtDomainFace.Text = generateCode.GeneratedCode();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 生成数据映射
        /// </summary>
        private void GeneratedORMapper()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Mapper, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //txtDataMapper.Text = generateCode.GeneratedCode();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 生成数据映射
        /// </summary>
        private void GeneratedORParameterMapper()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.MapperParameter, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //txtMapperParameter.Text = generateCode.GeneratedCode();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 生成界面
        /// </summary>
        private void GeneratedUI()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.UI, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //txtUI.Text = generateCode.GeneratedCode();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 脚本生成
        /// </summary>
        private void GeneratedSQLCode()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.SQLCode, DatabaseMapper.Instance.DatabaseType);
                //generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels, cbInsert.Checked, cbCheckData.Checked);

                //txtSql.Text = generateCode.GeneratedCode();
            }
            catch 
            {
            }
        }
        #endregion

        #region 主方法

        private void btnImport_Click(object sender, EventArgs e)
        {
            var list = ExcelToList.ExcelToModelClassList(ConstConstants.Const_ModelClass);
            BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Repository, DatabaseMapper.Instance.DatabaseType);
            //this.txtNew.Text = generateCode.GeneratedModelClassByList(list);
            //this.txtOld.Text = generateCode.GeneratedModelClassByListSingle(list);
            //this.richJason.Text = generateCode.GenerateJasonFunction(list);//生成Jason模型

        }

        private void btn_clear_click(object sender, EventArgs e)
        {
            //this.txtOld.Text = string.Empty;
            //this.txtNew.Text = string.Empty;

        }

        private void GenerateSpp()
        {
            try
            {
                BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Repository, DatabaseMapper.Instance.DatabaseType);
                generateCode.SetBaseCode(m_ConfigInfo, m_CurrentColumnModels);

                //this.txtSpp.Text = generateCode.GeneratedCode();

            }
            catch (Exception ex)
            {

                string a = ex.ToString();

            }


        }

        private void GenerateModelClass()
        {

            try
            {
                //BaseCode generateCode = GenerateCodeFactory.CreateGenerateCode(TemplateType.Repository, DatabaseMapper.Instance.DatabaseType);

                //this.txtNew.Text = generateCode.GeneratedModelClass(this.txtOld.Text);

                BaseCode code = new BaseCode();
                //this.txtNew.Text = code.GeneratedModelClass(this.txtOld.Text);

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }
        #endregion

        #region 生成htm 方法
        private void btntxt_Click(object sender, EventArgs e)
        {
            GenerateModelClass();
        }

        private void btn_sb_generate_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\n' });
                var sb = this.txt_sbname.Text.Trim();
                StringBuilder builder = new StringBuilder();
                builder.Append(string.Format("StringBuilder {0} = new StringBuilder();\r\n", sb));
                foreach (string str2 in strArray)
                {
                    string str3 = string.Empty;
                    //str3 = str2.Trim().Replace('\r', '\0');
                    str3 = str2;
                    if (!string.IsNullOrEmpty(str3))
                    {
                        //builder.Append(string.Format("{0}.Append(\"" + str3.Replace("\"", "\\\"") + "\");\r\n", sb));
                        //builder.Append(sb + ".Append(\"" + str3.Replace("\"", "\\\"") + "\");\r\n").ToString();
                        builder.Append(sb + ".Append(\"" + str3.Replace("\"", "\\\"") + "\");\r\n").ToString();
                        // builder.Append(sb + ".AppendLine( string.Format($@\"" + str3.Replace("\"", "\\\"") + "\"));\r\n").ToString();
                    }
                }
                builder.Append(string.Format("{0}.ToString();", sb));
                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = builder.ToString();
            }
        }

        private void btn_sb_copy_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_new.Text.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                Clipboard.SetDataObject(str);
            }

        }
        private void btn_htm_generate_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().ToString().TrimStart().Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\n' });
                StringBuilder builder = new StringBuilder();
                builder.Append("html=");
                builder.Append("\n");
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str3 = string.Empty;
                    //str3 = strArray[i].Trim().Replace('\r', '\0').Replace("{", "{{"); ;
                    //里面如果有逗号需要改成双引号
                    str3 = strArray[i].Trim().Replace('\r', '\0').Replace("'", "\"");

                    if (i == strArray.Length - 1)
                    {
                        //builder.Append(string.Format("{0}" + str3 + "{0}", "'"));
                        builder.Append("'" + str3 + "';");
                        builder.Append("\n");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(str3))
                        {
                            //builder.Append(string.Format("{0}" + str3 + "{0}+", "'"));
                            builder.Append("'" + str3 + "'+");
                            builder.Append("\n");
                        }

                    }

                }

                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = builder.ToString();
            }
        }

        private void btn_sb_single_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().ToString().TrimStart().Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\n' });
                StringBuilder builder = new StringBuilder();
                builder.Append("\n");
                for (int i = 0; i < strArray.Length; i++)
                {
                    string str3 = string.Empty;
                    //str3 = strArray[i].Trim().Replace('\r', '\0').Replace("{", "{{"); ;
                    //里面如果有逗号需要改成双引号
                    str3 = strArray[i].Trim().Replace('\r', '\0').Replace("'", "\"");
                    //builder.Append(string.Format("var htm_{1}={0}" + str3 + "{0};", "'",i.ToString()));

                    builder.Append("var htm_" + i.ToString() + "=" + "'" + str3 + "';");
                    builder.Append("\n");
                }
                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = builder.ToString();
            }
        }

        private void btn_sb_n_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\n' });
                var sb = this.txt_sbname.Text.Trim();
                StringBuilder builder = new StringBuilder();
                builder.Append(string.Format("List<string> {0} = new List<string>();\n", sb));
                foreach (string str2 in strArray)
                {
                    string str3 = string.Empty;
                    str3 = str2.Trim().Replace('\r', '\0');

                    if (!string.IsNullOrEmpty(str3))
                    {
                        var str_n = sb + ".Add(\"" + str3.Replace("\"", "\\\"") + "\".ToString());\r\n";
                        builder.Append(str_n);


                    }
                }
                builder.Append(string.Format("{0}.ToList();", sb));
                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = builder.ToString();

                //this.rich_sb_new.Text = DataTable_Js();

            }

        }
        #endregion

        #region 保存控件值方法
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            List<Control> list = new List<Control>();
            list.Add(this.txtClassName);
            list.Add(this.txtPK);
            list.Add(this.txtDescript);
            list.Add(this.txtColumns);
            list.Add(this.txt_sbname);
            //list.Add(this.txtDomainModel);
            //list.Add(this.txtDataMapper);
            //list.Add(this.txtMapperParameter);
            //list.Add(this.txtDomainFace);
            //list.Add(this.txtUI);
            //list.Add(this.txtSql);
            //list.Add(this.txtSpp);
            //list.Add(this.txtOld);
            //list.Add(this.txtNew);
            list.Add(this.rich_sb_old);
            list.Add(this.rich_sb_new);
            //list.Add(this.richJason);
            //list.Add(this.txtDateTime);
            //list.Add(this.txtGuid);
            //list.Add(this.txt_controller);
            //list.Add(this.txt_function);
            //list.Add(this.txt_return_type);
            FileOperate.saveAllForms(list);
        }
        #endregion

        #region 生成Function方法
        private void btn_sb_2_Click(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Split(new char[] { '\n' });
                var sb = this.txt_sbname.Text.Trim();
                StringBuilder builder = new StringBuilder();
                //builder.AppendLine();
                builder.Append(string.Format("StringBuilder {0} = new StringBuilder();\r\n", sb));
                foreach (string str2 in strArray)
                {
                    string str3 = string.Empty;
                    str3 = str2.Replace('\r', '\0');

                    if (!string.IsNullOrEmpty(str3))
                    {

                        var str_n = sb + ".AppendLine(\"" + str3.Replace("\"", "\\\"") + "\".ToString());\r\n";


                        //var str_n = str3;
                        builder.Append(str_n);


                    }
                }
                builder.Append(string.Format("{0}.ToString();", sb));
                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = builder.ToString();

                //this.rich_sb_new.Text = DataTable_Js();

            }

        }
        private void btnValidGenerate_Click(object sender, EventArgs e)
        {

        }
        private void btn_generate_name_Click(object sender, EventArgs e)
        {
            var sb_name = this.txt_sbname.Text.ToLower().Trim();
            StringBuilder sb_10 = new StringBuilder();
            sb_10.AppendLine("js_btn_" + sb_name.ToString());
            sb_10.AppendLine("js_span_" + sb_name.ToString().ToString());
            sb_10.AppendLine("js_select_" + sb_name.ToString().ToString());
            sb_10.AppendLine("js_div_" + sb_name.ToString().ToString());
            sb_10.AppendLine("js_hidden_" + sb_name.ToString().ToString());
            sb_10.AppendLine("js_form_" + sb_name.ToString().ToString());
            sb_10.AppendLine("js_input_" + sb_name.ToString());
            sb_10.AppendLine("js_date_from_" + sb_name.ToString());
            sb_10.AppendLine("js_date_to_" + sb_name.ToString());
            sb_10.AppendLine("js_input_begin_date_" + sb_name.ToString());
            sb_10.AppendLine("js_input_end_date_" + sb_name.ToString());
            sb_10.AppendLine("js_btn_cancel_" + sb_name.ToString());
            sb_10.AppendLine("js_btn_save_" + sb_name.ToString());
            sb_10.AppendLine("js_btn_submit_" + sb_name.ToString());
            sb_10.AppendLine("js_btn_del_" + sb_name.ToString());
            sb_10.AppendLine("js_btn_export_" + sb_name.ToString());
            sb_10.AppendLine("#js_edit_modal_" + sb_name.ToString());
            sb_10.AppendLine("#js_add_modal_" + sb_name.ToString());
            sb_10.AppendLine("js_checkbox_" + sb_name.ToString());
            sb_10.ToString();
            this.rich_sb_new.Text = sb_10.ToString();
        }
        private void btn_spp_generate_Click(object sender, EventArgs e)
        {
            //var return_type = this.txt_return_type.Text;
            //var controller = this.txt_controller.Text;
            //var function = this.txt_function.Text;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//responsitory 方法".ToString());
            sb.AppendLine("   public List<ContractList_Search_Common_VM> ContractList_Search_Common()".ToString());
            sb.AppendLine("        {".ToString());
            sb.AppendLine("               List<ContractList_Search_Common_VM> vm = new List<ContractList_Search_Common_VM>();".ToString());
            sb.AppendLine("            return vm;".ToString());
            sb.AppendLine("        }".ToString());
            sb.AppendLine("List<ContractList_Search_Common_VM> ContractList_Search_Common();".ToString());
            sb.AppendLine("//service 接口".ToString());
            sb.AppendLine("List<ContractList_Search_Common_VM> ContractList_Search_Common();".ToString());
            sb.AppendLine("//service 方法".ToString());
            sb.AppendLine("        public List<ContractList_Search_Common_VM> ContractList_Search_Common()".ToString());
            sb.AppendLine("        {".ToString());
            sb.AppendLine("            return contractmRepository.ContractList_Search_Common();".ToString());
            sb.AppendLine("        }".ToString());
            sb.AppendLine("//api 接口".ToString());
            sb.AppendLine("[HttpGet]".ToString());
            sb.AppendLine("[IgnoreDBAuthorize]".ToString());
            sb.AppendLine("  public List<ContractList_Search_Common_VM> ContractList_Search_Common_API()".ToString());
            sb.AppendLine("        {".ToString());
            sb.AppendLine("            return e_ContractService.ContractList_Search_Common();".ToString());
            sb.AppendLine("        }".ToString());
            sb.AppendLine("//web controller".ToString());
            sb.AppendLine("            ContractList_Search_Common_VM vm = new ContractList_Search_Common_VM();".ToString());
            sb.AppendLine("            var company_apiUrl = \"E_Contract/ContractList_Search_Common_API\";".ToString());
            sb.AppendLine("            HttpResponseMessage responMessage = APIHelper.APIPostAsync(vm, company_apiUrl);".ToString());
            sb.AppendLine("            var result = responMessage.Content.ReadAsStringAsync().Result;".ToString());
            sb.AppendLine("            var resultModel = JsonConvert.DeserializeObject<ContractList_Search_Common_VM>(result);".ToString());
            sb.AppendLine("            return View(resultModel);".ToString());
            sb.ToString();

            //sb.Replace("List<ContractList_Search_Common_VM>", return_type);
            //sb.Replace("ContractList_Search_Common", function);
            //sb.Replace("E_Contract", controller);
            //this.rich_function.Text = sb.ToString();
        }
        #endregion

        #region 根据字段拼接名称生成 ModelClass

        private void btnInsertModelClass_Click(object sender, EventArgs e)
        {
            //if (this.txtOld.Text.Trim() != string.Empty)
            //{
            //    FrmInsertModel frm = new FrmInsertModel();
            //    List<ModelClass> list = BaseCode.GetModelClassList(this.txtOld.Text);
            //    string re = string.Empty;

            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        frm.ModelName = list[0].TableName;
            //        if (i == list.Count - 1)
            //        {
            //            re = re + list[i].ColumnName;
            //        }
            //        else
            //        {
            //            re = re + list[i].ColumnName + ",";
            //        }

            //    }
            //    frm.ColumnStr = re;
            //    frm.ModelClassList = list;
            //    frm.ShowDialog();
            //    this.txtOld.Text = frm.ModelText;
            //}


        }
        #endregion

        #region ItemModel

        private void btn_ItemModel_Click(object sender, EventArgs e)
        {
            FrmItemModel frm = new FrmItemModel();
            frm.ShowDialog();

        }
        #endregion

        private void btn_template(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConstConstants.Const_ModelClass);
        }

        private void btn_ExportItemMode_Click(object sender, EventArgs e)
        {
            List<ModelClass> list_Item_Model = ExcelToList.ExcelToModelClassList(ConstConstants.Const_ModelClass);
            List<Item_Model> list = new List<Item_Model>();
            list = list_Item_Model.Select(
                   m => new Item_Model
                   {
                       Item_1 = m.TableName,
                       Item_2 = m.ColumnName,
                       Item_3 = m.ColumnUI_DisplayName,
                       Item_4 = m.DataType,
                       Item_5 = m.Is_Identity,
                       Item_6 = m.ColumnRemarks,
                       Item_7 = m.ColumnType,
                       Item_8 = m.ColumnDefaultValue,
                       Item_9 = m.ColumnUI_ID,
                       Item_10 = m.ColumnUI_Type,
                       Item_11 = m.JasonDefaultValue,
                       Item_12 = m.Is_Null
                   }
                    ).ToList();

            DataTable dt = list.ToDataTable<Item_Model>();
            ExcelExtensions.ExportExcelWithAspose(dt, ConstConstants.Item_Model_Path);
            System.Diagnostics.Process.Start(ConstConstants.Item_Model_Path);

        }

    }
}


#region 无用
public static class StringHelper
{
    public static string ToStringToN(this string s)
    {
        return s + "\n";
    }
}
#endregion