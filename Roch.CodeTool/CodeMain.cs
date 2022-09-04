
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
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Roch.DomainModel;
using System.Linq;
using System.Dynamic;
using Roch.Framework;
using System.CodeDom.Compiler;
using System.CodeDom;
using Dapper;
using System.Data.SQLite;

namespace Roch.CodeTool
{
    /// <summary>
    /// 主界面加载
    /// </summary>
    public partial class CodeMain : BaseForm
    {
        private List<ColumnModel> m_CurrentColumnModels;
        private UserConfigInfo m_ConfigInfo;
        private string m_DirPath;
        private string m_DebugPath;
        public static string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string sqlitePath = AppDomain.CurrentDomain.BaseDirectory + @"db.db";
        public SQLiteHelper sqlLiteHelper = null;

        public CodeMain()
        {
            InitializeComponent();
            InitVarialy();
        }

        private void InitVarialy()
        {
            m_CurrentColumnModels = new List<ColumnModel>();
            m_ConfigInfo = new UserConfigInfo();
            m_ConfigInfo.UserName = ConfigurationManager.AppSettings["UserName"];
            m_ConfigInfo.Email = ConfigurationManager.AppSettings["Email"];
            m_ConfigInfo.NameSpace = ConfigurationManager.AppSettings["NameSpace"];

            m_DirPath = ConfigurationManager.AppSettings["SavePath"];
            m_DebugPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string ConnectString()
        {

            return $"data source={sqlitePath};version=3;";


        }

        private void CodeMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists(sqlitePath))
            {
                MessageBox.Show("DB数据故障！", "连接失败");
                return;
            }
            sqlLiteHelper = new SQLiteHelper(sqlitePath);
            for (int i = 0; i < 12; i++)
            {
                string sql = string.Format("insert into wechat (number,sex) values ('{0}','{1}')", i.ToString(), "未知");
                int qwe = sqlLiteHelper.ExeSqlOut(sql);
            }

            var foos = new List<wechat>();
            foos.Add(new wechat { number = "1312312", sex = "213123" });

            using (IDbConnection cnn = new SQLiteConnection(ConnectString()))
            {
                cnn.Open();
                var output = cnn.Query<wechat>("select * from wechat", new DynamicParameters());
                var a= output.ToList();
            }


            //var count = connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)", foos);
            //Assert.Equal(foos.Count, count);




            //tsbServer.PerformClick();
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
            FileOperate.loadAllForms(list);
        }

        private void tsmSave_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tbControl.SelectedTab;
            if (tabPage.Controls.Count == 1)
            {
                //if (ShowQuestion("确认要保存吗？") == DialogResult.No)
                //{
                //    return;
                //}

                if (tabPage.Controls[0] is RichTextBox)
                {
                    try
                    {
                        RichTextBox richText = tabPage.Controls[0] as RichTextBox;
                        if (!Directory.Exists(m_DirPath))
                        {
                            Directory.CreateDirectory(m_DirPath);
                        }

                        string fileName = string.Format("{0}.cs", m_ConfigInfo.ClassName);
                        if (tabPage.Tag != null)
                        {
                            fileName = fileName.Insert(fileName.IndexOf("."), tabPage.Tag.ToString());
                        }

                        //richText.SaveFile(Path.Combine(m_DirPath, fileName));
                        richText.SaveFile(Path.Combine(m_DirPath, fileName), RichTextBoxStreamType.PlainText);

                        ShowPrompt("保存成功");
                    }
                    catch
                    {
                        ShowPrompt("保存失败");
                    }
                }
                else if (tabPage.Controls[0] is DataGridView)
                {
                    ShowPrompt("表格");
                }
            }
        }

        private void tsSelect_Click(object sender, EventArgs e)
        {


            TabPage tabPage = tbControl.SelectedTab;
            if (tabPage.Controls.Count == 1)
            {
                if (tabPage.Controls[0] is RichTextBox)
                {
                    try
                    {
                        RichTextBox richText = tabPage.Controls[0] as RichTextBox;
                        richText.SelectAll();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void tsCopy_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tbControl.SelectedTab;
            if (tabPage.Controls.Count == 1)
            {
                if (tabPage.Controls[0] is RichTextBox)
                {
                    try
                    {
                        RichTextBox richText = tabPage.Controls[0] as RichTextBox;
                        richText.Copy();
                    }
                    catch
                    {
                    }
                }
            }
        }

        //private void btnGenerated_Click(object sender, EventArgs e)
        //{

        //}

        private void btnSetProperty_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tbControl.SelectedTab;
            if (tabPage.Controls.Count == 1)
            {

                //sb.AppendLine(string.Format($@"{replace_1}<app-nav-breadcrumbs></app-nav{replace_1}-breadcrumbs"));
                if (tabPage.Controls[0] is DataGridView)
                {
                    try
                    {
                        //for (int i = 0; i < dataGrid.Rows.Count; i++)
                        //{
                        //    ColumnModel tempColumnModel = m_CurrentColumnModels.Find(c => c.ID == Convert.ToUInt64(dataGrid.Rows[i].Cells["colID"].Value));

                        //    if (tempColumnModel != null)
                        //    {
                        //        tempColumnModel.Name = dataGrid.Rows[i].Cells["colName"].Value.ToString().Trim();
                        //    }
                        //}
                    }
                    catch
                    {

                    }
                }
            }
        }

        //private void btnGenerated_Click(object sender, EventArgs e)
        //{

        //}

        private void btnNoData_Click(object sender, EventArgs e)
        {
            //this.txtOld.Text = string.Empty;
            //this.txtNew.Text = string.Empty;
        }

        //private void btn_sb_generate_Click(object sender, EventArgs e)
        //{

        //}

        private void btn_sb_generate_Click1(object sender, EventArgs e)
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
                        if (str3.Contains("{") || str3.Contains("}"))
                        {
                            builder.Append(sb + ".AppendLine(\"" + str3.Replace("\"", "\\\"") + "\");\r\n").ToString();
                        }
                        else
                        {
                            builder.Append(sb + ".AppendLine($\"" + str3.Replace("\"", "\\\"") + "\");\r\n").ToString();
                        }

                        //builder.Append(string.Format("{0}.AppendLine(\"" + str3.Replace("\"", "\\\"") + "\");\r\n", sb));
                        //builder.Append(sb + ".AppendLine( string.Format($@\"" + str3.Replace("\"", "\\\"") + "\"));\r\n").ToString();

                    }
                }


                this.rich_sb_new.Text = string.Empty;
                this.rich_sb_new.Text = getHtml(builder.ToString());
            }

        }


        public string getHtml(string content)
        {
            var str = Guid.NewGuid().ToString().Replace('-', '_');
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static string  replace_method{str}(InputData inputData)");
            sb.AppendLine("        {");
            sb.AppendLine(content);
            sb.AppendLine($"            return sb.ToString().TrimEnd(',');");
            sb.AppendLine("        }");
            return sb.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = string.Empty;
            string keyname = this.txt_sbname.Text.Trim();
            string body = GetTemplateStr(this.rich_sb_old.Text.Trim());
            this.rich_sb_new.Text = ChildStr("描述", keyname, body);
        }

        public string ChildStr(string description, string keyname, string body)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\"" + keyname + "\": {");
            sb.AppendLine("		\"scope\": \"javascript,typescript,html\",");
            sb.AppendLine("		\"prefix\": \"" + keyname + "\",");
            sb.AppendLine("		\"body\": [");
            sb.AppendLine("	" + body);
            sb.AppendLine("		],");
            sb.AppendLine("		\"description\": \"" + description + "\"");
            return sb.ToString();

        }


        public string GetTemplateStr(string str)
        {
            StringBuilder sb = new StringBuilder();
            string[] strArray = str.Split(new char[] { '\n' });
            foreach (string str2 in strArray)
            {
                //str2.Dump();
                if (!string.IsNullOrEmpty(str2.Trim()))
                {
                    var temp = "\"" + str2 + "\"" + ",";
                    sb.AppendLine(temp);

                }
            }
            return sb.ToString();
        }


        //生成 linqPad文件
        private void button4_Enter(object sender, EventArgs e)
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            var list = str.Split(new[] { '\t', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            this.rich_sb_new.Text = replace_method(list);
        }

        public static string replace_method(List<string> list)
        {

            var json_str = string.Join(",", list);
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"<Query Kind=\"Program\" />");
            sb.AppendLine($"void Main()");
            sb.AppendLine("{");
            sb.AppendLine($"string sql=@\"");
            sb.AppendLine($"  {json_str}");
            sb.AppendLine($" \";");
            sb.AppendLine($"sql=sql.Replace(\"[\",\"\");");
            sb.AppendLine($"sql=sql.Replace(\"]\",\"\");");
            sb.AppendLine("var list =sql.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();");
            sb.AppendLine($"for(int i =0 ;i<list.Count;i++)");
            sb.AppendLine("{");
            sb.AppendLine($"var Item =list[i].Trim();");
            sb.AppendLine($"StringBuilder sb = new StringBuilder();");
            sb.AppendLine("sb.AppendLine($\" {Item}\");");
            sb.AppendLine($"sb.ToString().Dump();");
            sb.AppendLine("}");
            sb.AppendLine("}");

            return sb.ToString().TrimEnd(',');
        }

        public string replace_methodc4e29e2f_7d3a_49cf_8b3d_c2a84b069cdd()
        {
            List<string> list = getListString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"DECLARE @table AS TABLE (");

            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb.AppendLine($"			{Item} nvarchar(200)");
                }
                else
                {
                    sb.AppendLine($"			{Item} nvarchar(200),");
                }

            }

            sb.AppendLine($"		)");
            sb.AppendLine(replace_methodfd2f0428_fbeb_4f81_bfa6_8fcb08b6b2f8());
            return sb.ToString().TrimEnd(',');
        }



        private void button5_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = replace_methodc4e29e2f_7d3a_49cf_8b3d_c2a84b069cdd();
        }

        public List<string> getListString()
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            var list = str.Split(new[] { '\t', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return list;
        }

        public List<string> getListAppline()
        {
            string str = this.rich_sb_old.Text.ToString().TrimStart().Trim();
            var list = str.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            return list;
        }

        public List<string> getWTMEnitiyList()
        {
            return getListString().Where(m => m.ToStringToN().ToLower().Contains("entity.")).Select(x => x.ToString().Replace("\"", "").Replace("Entity.", "").Replace(":", "").Trim().TrimStart()).Distinct().ToList<string>();
        }

        public string WTMEnitiyJson()
        {
            var list = getWTMEnitiyList();
            string temp = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                temp = temp + list[i].ToString() + ": " + "\"" + "\"" + ",";

            }
            temp = temp.TrimEnd(',');


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("formData : {");
            sb.AppendLine("        Entity: {");
            sb.AppendLine($"            {temp}");
            sb.AppendLine("        }");
            sb.AppendLine("    },");
            return sb.ToString();
        }

        public string ListStr()
        {
            List<string> list = getListString();
            return string.Join(",", list);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = replace_method(getListString());
        }

        public string replace_methodfd2f0428_fbeb_4f81_bfa6_8fcb08b6b2f8()
        {
            List<string> list = getListString();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--insert @table({ListStr()}) select {ListStr()} from #temp");

            return sb.ToString().TrimEnd(',');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //dynamic foo = new ExpandoObject();
            //foo.Bar = "something";
            //foo.Test = true;
            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
            var list = new List<Dictionary<string, object>>();

            var vm = getRichTextBoxToVM();
            List<string> FirstRow = vm.FirstRow;
            List<List<string>> Rows = vm.Rows;
            for (int i = 0; i < Rows.Count; i++)
            {
                //list.Add(new Dictionary<string, object> { { "ID", 1 }, { "Product", "Pie" }, { "Days", 1 }, { "QTY", 65 } });
                Dictionary<string, object> d = new Dictionary<string, object>();
                for (int j = 0; j < FirstRow.Count; j++)
                {
                    d.Add(FirstRow[j].ToString(), Rows[i][j].ToString().Trim());
                }
                list.Add(d);
            }
            this.rich_sb_new.Text = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            //String str = JSONObject.toJSONString(strList);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = this.WTMEnitiyJson();
        }

        public List<string> richboxToList()
        {
            List<string> values = new List<string>();
            for (int i = 0; i < rich_sb_old.Lines.Length; i++)
            {
                string value = string.Empty;
                if (i == rich_sb_old.Lines.Length - 1)
                {
                    int startIndex = this.rich_sb_old.GetFirstCharIndexFromLine(i);
                    value = this.rich_sb_old.Text.Substring(startIndex, this.rich_sb_old.Text.Length - startIndex);
                }
                else
                {
                    int startIndex = this.rich_sb_old.GetFirstCharIndexFromLine(i);
                    int endIndex = this.rich_sb_old.GetFirstCharIndexFromLine(i + 1) - 1;
                    value = this.rich_sb_old.Text.Substring(startIndex, endIndex - startIndex + 1);
                }

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Trim() != "")
                    {
                        values.Add(value);
                    }
                }
            }
            return values;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            var list = richboxToList();
            for (int i = 0; i < list.Count; i++)
            {
                var Item = changeStrToList(list[i]);
                if (i == 0)
                {

                    sb.AppendLine(ListToSQLTable(Item));
                    sb.AppendLine("insert @table");
                }
                else
                {
                    if (i == list.Count - 1)
                    {
                        sb.AppendLine(ListToSelectColunmData(Item, ""));
                    }
                    else
                    {
                        sb.AppendLine(ListToSelectColunmData(Item, "  union all"));
                    }

                }

            }
            sb.AppendLine("select * from @table");
            this.rich_sb_new.Text = sb.ToString();
        }

        public string ListToSQLTable(List<string> list)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"DECLARE @table AS TABLE (");

            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb.AppendLine($"			{Item} nvarchar(200)");
                }
                else
                {
                    sb.AppendLine($"			{Item} nvarchar(200),");
                }
            }
            sb.AppendLine($"		)");
            return sb.ToString().TrimEnd(',');

        }



        public string ListToSelectColunmData(List<string> list, string splitstr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ");
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {

                    sb.Append($"N'{Item}'");
                }
                else
                {
                    sb.Append($"N'{Item}',");
                }

            }
            sb.AppendLine(splitstr);
            return sb.ToString().TrimEnd(',');

        }

        private List<string> changeStrToList(string str) //
        {
            str = str.Replace('\n', '\t');
            List<string> list = new List<string>();
            list = str.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            //list = str.Split(new[] { '\t' }).ToList<string>();
            return list;

        }

        public static string Generate_List(RichTextBoxModel vm)
        {
            string tempLine = string.Empty;
            if (vm.FirstRow != null)
            {
                foreach (var item in vm.FirstRow)
                {
                    tempLine = tempLine + $"间隔 $Foreach.{item.ToString()}$";
                }

            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"void Main()");
            sb.AppendLine("{");
            sb.AppendLine($"   List<Model> list =new List<Model>();");
            //sb.AppendLine($"   list.Add(new Model{ Item1 =\"1\",Item2=\"1\"});");
            var str = GetModel(vm);
            sb.AppendLine(str);
            sb.AppendLine($"list.Dump();");
            sb.AppendLine($"Extention.GetTemplateString(@\"{tempLine}\",list).Dump();");
            sb.AppendLine("}");
            sb.AppendLine($"public class Model");
            sb.AppendLine("{");

            if (vm.FirstRow != null)
            {
                foreach (var item in vm.FirstRow)
                {
                    sb.AppendLine("  public string " + item.ToString().Trim() + " {get;set;}");
                }
                sb.AppendLine("}");
            }

            sb.AppendLine(ExtentionClass(vm));

            return sb.ToString().TrimEnd(',');


        }

        public static string GetModel(RichTextBoxModel vm)
        {

            StringBuilder result = new StringBuilder();
            var FirstModel = vm.FirstRow;
            var DataRow = vm.Rows;
            for (int i = 0; i < DataRow.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < FirstModel.Count; j++)
                {
                    sb.Append(FirstModel[j].ToString() + "=" + "\"" + DataRow[i][j].ToString() + "\"" + ",");
                }
                result.AppendLine("list.Add(new Model{ " + sb.ToString().TrimEnd(',') + " });");
                result.AppendLine("");
            }
            return result.ToString();

        }





        private void button9_Click(object sender, EventArgs e)
        {
            var vm = getRichTextBoxToVM();
            this.rich_sb_new.Text = Generate_List(vm);

        }

        public RichTextBoxModel getRichTextBoxToVM()
        {
            RichTextBoxModel vm = new RichTextBoxModel();
            List<List<string>> datalist = new List<List<string>>();
            var list = richboxToList();

            for (int i = 0; i < list.Count; i++)
            {
                var Item = changeStrToList(list[i]);
                if (Item != null)
                {
                    if (i == 0)
                    {
                        vm.FirstRow = Item;
                    }
                    else
                    {
                        datalist.Add(Item);
                    }
                }
            }
            vm.Rows = datalist;
            return vm;
        }

        private void CodeMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = GetCommon();
        }

        public string GetCommon()
        {
            StringBuilder last = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            var vm = getRichTextBoxToVM();
            List<string> list = vm.FirstRow;
            foreach (var item in list)
            {
                sb.Append($"{item.ToString().Trim()} = m.{item.ToString().Trim()},");
            }
            var reustt = sb.ToString().TrimEnd(',');
            last.AppendLine("list.Select(m=> new { " + reustt + " }).ToList();");
            // 后面可以继续添加

            return last.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(this.rich_sb_old.Text.ToString()), writer, null);
                    this.rich_sb_new.Text = "string templateString=" + writer.ToString() + ";";
                }
            }

        }

        public static string ExtentionClass(RichTextBoxModel vm)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static class Extention");
            sb.AppendLine("{");
            // 方法1 
            sb.AppendLine($"public  static string GetTemplateString(string templateString, List<Model> list)");
            sb.AppendLine("{");
            sb.AppendLine($"    StringBuilder sb = new StringBuilder();");
            sb.AppendLine($"    for (int i = 0; i < list.Count; i++)");
            sb.AppendLine("    {");
            sb.AppendLine($"        var temp = templateString;");
            foreach (var item in vm.FirstRow)
            {
                sb.AppendLine($"        temp = temp.Replace(\"$Foreach.{item.ToString()}$\", list[i].{item.ToString()});");
            }
            sb.AppendLine($"        sb.AppendLine(temp);");
            sb.AppendLine("    }");
            sb.AppendLine("    return sb.ToString(); ");
            sb.AppendLine("}");
            // 方法二
            sb.AppendLine($"public  static  string GeTemplateSingle(string templateString,List<string> list)");
            sb.AppendLine("{");
            sb.AppendLine($"    StringBuilder sb = new StringBuilder();");
            sb.AppendLine($"    for (int i = 0; i < list.Count; i++)");
            sb.AppendLine("    {");
            sb.AppendLine($"        var temp = templateString;");
            sb.AppendLine($"        temp = temp.Replace(\"$Foreach.String$\", list[i].ToString());");
            sb.AppendLine($"        sb.AppendLine(temp);");
            sb.AppendLine("    }");
            sb.AppendLine($"    return sb.ToString();");
            sb.AppendLine("}");


            sb.AppendLine("}");



            return sb.ToString();

        }
    }

    public class RichTextBoxModel
    {

        public List<string> FirstRow { get; set; }
        public List<List<string>> Rows { get; set; }


    }


}
