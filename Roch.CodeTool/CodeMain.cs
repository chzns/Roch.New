
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
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Reflection;

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
        //public static string sqlitePath = AppDomain.CurrentDomain.BaseDirectory + @"db.db";
        public static string sqlitePath = ConfigurationManager.AppSettings["SqlLitePath"];
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

        private void SQLLiteMethod()
        {
            if (!File.Exists(sqlitePath))
            {
                MessageBox.Show("DB数据不存在！", "连接失败");
                File.Create(sqlitePath);
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
                var a = output.ToList();
            }

        }

        private void SaveSQLLiteMethod()
        {
            if (!File.Exists(sqlitePath))
            {
                MessageBox.Show("DB数据不存在,已重新创建,请关闭重新打开软件", "连接失败");
                File.Create(sqlitePath); // 创建数据库
                return;
            }
            else
            {
                sqlLiteHelper = new SQLiteHelper(sqlitePath);
                // 创建表
                string sql_count = "SELECT name FROM sqlite_master WHERE type='table' AND name='Settings'";
                bool bo = sqlLiteHelper.RunSql(sql_count);
                if (bo == false)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"CREATE TABLE \"Settings\" (");
                    sb.AppendLine($"	\"Name\"	TEXT UNIQUE,");
                    sb.AppendLine($"	\"Text\"	TEXT,");
                    sb.AppendLine($"	\"CreateDate\"	INTEGER,");
                    sb.AppendLine($"	PRIMARY KEY(\"Name\")");
                    sb.AppendLine($")");
                    sqlLiteHelper.ExeSqlOut(sb.ToString());

                }

                //SQLiteCommand cmd = new SQLiteCommand("insert into Settings ([Name],[Text],[CreateDate]) values (@Name,@Text,@CreateDate)");
                //cmd.Parameters.Add("@Name", DbType.String).Value = Guid.NewGuid().ToString();
                //cmd.Parameters.Add("@Text", DbType.String).Value = this.rich_sb_new.Text;
                //cmd.Parameters.Add("@CreateDate", DbType.String).Value = DateTime.Now.ToString("yyyyMMddHHmmss");

                string sql = string.Format("insert into Settings ([Name],[Text],[CreateDate]) values ('{0}','{1}','{2}')", Guid.NewGuid().ToString(), this.rich_sb_new.Text, DateTime.Now.ToString("yyyyMMddHHmmss"));
                int qwe = sqlLiteHelper.ExeSqlOut(sql);
                //int qwe = sqlLiteHelper.ExeSqlOut(cmd.CommandText);
                if (qwe > 0)
                {
                    MessageBox.Show("保存成功！", "提示");
                }
            }


        }

        private void GetSQLLiteMethod()
        {
            //
            if (!File.Exists(sqlitePath))
            {
                MessageBox.Show("DB数据不存在,已重新创建,请关闭重新打开软件", "连接失败");
                File.Create(sqlitePath); // 创建数据库
                return;
            }
            else
            {
                sqlLiteHelper = new SQLiteHelper(sqlitePath);
                // 创建表
                string sql_count = "SELECT name FROM sqlite_master WHERE type='table' AND name='Settings'";
                bool bo = sqlLiteHelper.RunSql(sql_count);
                if (bo == false)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"CREATE TABLE \"Settings\" (");
                    sb.AppendLine($"	\"Name\"	TEXT UNIQUE,");
                    sb.AppendLine($"	\"Text\"	TEXT,");
                    sb.AppendLine($"	\"CreateDate\"	TEXT,");
                    sb.AppendLine($"	PRIMARY KEY(\"Name\")");
                    sb.AppendLine($")");
                    sqlLiteHelper.ExeSqlOut(sb.ToString());

                }


                string sql = string.Format("select * from Settings order by  cast(CreateDate as type) desc limit 1");
                DataTable dt = sqlLiteHelper.SearchSql(sql);

                if (dt.Rows.Count > 0)
                {
                    List<Settings> list = dt.ToList<Settings>();
                    MessageBox.Show(list.FirstOrDefault()?.Text.ToString());

                    //MessageBox.Show(dt[0][0], "提示");
                }
            }

        }

        RichTextBoxModel constRichTextBoxModel = new RichTextBoxModel();

        private void CodeMain_Load(object sender, EventArgs e)
        {

            //List<Control> list = new List<Control>();

            FileOperate.loadAllForms(getControlList());
            constRichTextBoxModel = this.getRichTextBoxToVM();
            this.richReplace.WordWrap = false;
            this.richFK.WordWrap = false;
            this.rich_sb_new.WordWrap = false;
            this.rich_sb_old.WordWrap = false;
            this.groupBox1.Text = string.Empty;
            this.groupBox2.Text = string.Empty;
            this.groupBox3.Text = string.Empty;
            this.groupBox4.Text = string.Empty;
            this.groupBox5.Text = string.Empty;
            this.groupBox5.Text = string.Empty;
            this.groupBox6.Text = string.Empty;
            this.groupBox7.Text = string.Empty;
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
            sb.AppendLine($"string sql=@\"{json_str}\";");
            sb.AppendLine($"sql=sql.Replace(\"[\",\"\");");
            sb.AppendLine($"sql=sql.Replace(\"]\",\"\");");
            sb.AppendLine("var list =sql.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();");
            sb.AppendLine($"for(int i =0 ;i<list.Count;i++)");
            sb.AppendLine("{");
            sb.AppendLine($"var Item =list[i].Trim();");
            sb.AppendLine($"StringBuilder sb = new StringBuilder();");
            sb.AppendLine("sb.Append($\" {Item}\");");
            sb.AppendLine($"sb.ToString().Dump();");



            sb.AppendLine("}");

            sb.AppendLine($"\"-------\".Dump();");
            sb.AppendLine($"Extention.GeTemplateSingle(@\"");
            sb.AppendLine($"$Foreach.String$");
            sb.AppendLine($"间隙");
            sb.AppendLine($"$Foreach.String$\",list).Dump();");

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
            StringBuilder sb = new StringBuilder();
            List<string> list = getListString();
            sb.AppendLine(replace_method(list));

            RichTextBoxModel vm = new RichTextBoxModel();
            sb.AppendLine(ExtentionClass(vm));



            this.rich_sb_new.Text = sb.ToString();
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
            List<List<string>> Rows = vm.OtherRows;
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

        public List<string> richboxToListOld()
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

        public List<string> richboxToList()
        {
            var list = this.rich_sb_old.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> reList = new List<string>();
            foreach (var item in list)
            {
                reList.Add(item.ToString().Trim());
            }
            return reList;
        }



        public static void RunAsync(Action action)
        {
            ((Action)(delegate ()
            {
                action.Invoke();
            })).BeginInvoke(null, null);
        }

        public void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate ()
            {
                action.Invoke();
            }));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //generateSQL();
            generateSQL();
        }

        public void generatePGSQL()
        {
            StringBuilder sb = new StringBuilder();
            var list = richboxToList();
            this.rich_sb_new.Text = replace_method9(list);
            //for (int i = 0; i < list.Count; i++)
            //{
            //    var Item = changeStrToList(list[i]);
            //    if (i == 0)
            //    {
            //        sb.AppendLine(ListToSQLTable(Item));
            //        sb.AppendLine("insert @table");
            //    }
            //    else
            //    {
            //        if (i == list.Count - 1)
            //        {
            //            sb.AppendLine(ListToSelectColunmData(Item, ""));
            //        }
            //        else
            //        {
            //            sb.AppendLine(ListToSelectColunmData(Item, "  union all"));
            //        }
            //    }
            //}
            //sb.AppendLine("select * from @table");
            //var select_col = ListToSelectSQL(changeStrToList(list[0]));
            //sb.AppendLine($"--insert @table({select_col}) select {select_col} from @table");

            //// update 
            //var SingleItem = changeStrToList(list[0]);
            //sb.AppendLine(getYouBiao(SingleItem));
            //this.rich_sb_new.Text = sb.ToString();

        }

        public static string replace_method9(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-- Table: public.CreateTable");
            sb.AppendLine($"-- DROP TABLE IF EXISTS public.\"CreateTable\";");
            sb.AppendLine($"CREATE TABLE IF NOT EXISTS public.\"CreateTable\"");
            sb.AppendLine($"(");
            sb.AppendLine($"    \"ID\" uuid NOT NULL,");

            foreach (var item in list)
            {
                sb.AppendLine($"    \"{item.ToString()}\" character varying(255) COLLATE pg_catalog.\"default\",");
            }

            sb.AppendLine($"    CONSTRAINT \"PK_CreateTable\" PRIMARY KEY (\"ID\")");
            sb.AppendLine($")");
            sb.AppendLine($"TABLESPACE pg_default;");
            sb.AppendLine($"ALTER TABLE IF EXISTS public.\"CreateTable\"");
            sb.AppendLine($"    OWNER to postgres;");

            for (int i = 0; i < 6; i++)
            {

                sb.AppendLine(getColumn(list, "PGType1"));

            }
            sb.Append("SELECT");
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb.Append($"\"{Item}\"");
                }
                else
                {
                    sb.Append($"\"{Item}\",");
                }
            }
            sb.AppendLine($" FROM public.\"CreateTable\";");

            return sb.ToString().TrimEnd(',');
        }



        public static string getColumn(List<string> list, string Type)
        {

            StringBuilder sb = new StringBuilder();
            if (Type == "PGType1")
            {
                sb.Append($"INSERT INTO public.\"CreateTable\"");
                sb.Append("(");
                sb.Append($"\"ID\",");
                for (int i = 0; i < list.Count; i++)
                {
                    var Item = list[i].ToString().Trim();
                    if (i == list.Count - 1)
                    {
                        sb.Append($"\"{Item}\"");
                    }
                    else
                    {
                        sb.Append($"\"{Item}\",");
                    }
                }
                sb.Append(")VALUES(");
                var a = Guid.NewGuid();
                sb.Append($"'{a}',");

                for (int i = 0; i < list.Count; i++)
                {
                    Random r = new Random();
                    int ran = r.Next(i, 1000);

                    var Item = list[i].ToString().Trim();
                    if (i == list.Count - 1)
                    {
                        ran = r.Next(i, 1000);
                        sb.Append($"'{list[i].ToString()}{i.ToString()}'");
                    }
                    else
                    {
                        ran = r.Next(i, 1000);
                        sb.Append($"'{list[i].ToString()}{i.ToString()}',");
                    }
                }
                sb.Append(");");


            }
            //if (Type == "PGType2")
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        var Item = list[i].ToString().Trim();
            //        if (i == list.Count - 1)
            //        {
            //            sb.Append($"\"{Item}\"");
            //        }
            //        else
            //        {
            //            sb.Append($"\"{Item}\",");
            //        }
            //    }

            //}

            return sb.ToString().TrimEnd(',');
        }


        public void generateSQL()
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
            var select_col = ListToSelectSQL(changeStrToList(list[0]));
            sb.AppendLine($"--insert @table({select_col}) select {select_col} from @table");

            // update 
            var SingleItem = changeStrToList(list[0]);
            sb.AppendLine(getYouBiao(SingleItem));
            this.rich_sb_new.Text = sb.ToString();

        }

        public string getYouBiao(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            var select_col = ListToSelectSQL(list);
            var define_col = ListToSelectDefineSQL(list);
            foreach (var item in list)
            {
                sb.AppendLine($"declare @{item.ToString().Trim()} nvarchar(20)     ");
            }

            sb.AppendLine($"declare mycursor cursor for SELECT {select_col} FROM @table");
            sb.AppendLine($"open mycursor      ");
            sb.AppendLine($"fetch next from mycursor into {define_col} ");
            sb.AppendLine($"while (@@fetch_status=0)  ");
            sb.AppendLine($"begin        ");

            foreach (var item in list)
            {
                sb.AppendLine($"	print @{item} ");
            }

            sb.AppendLine($"	fetch next from mycursor into {define_col} ");
            sb.AppendLine($"end  ");
            sb.AppendLine($"close mycursor  ");
            sb.AppendLine($"DEALLOCATE mycursor");
            return sb.ToString();

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

        public string ListToSelectSQL(List<string> list)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb.Append($"{Item}");
                }
                else
                {
                    sb.Append($"{Item},");
                }
            }
            return sb.ToString().TrimEnd(',');
        }

        public string ListToSelectDefineSQL(List<string> list)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb.Append($"@{Item}");
                }
                else
                {
                    sb.Append($"@{Item},");
                }
            }
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
            str = str.Replace("'", "");
            str = str.Replace(",", "");
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
            var DataRow = vm.OtherRows;
            for (int i = 0; i < DataRow.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < FirstModel.Count; j++)
                {
                    try
                    {
                        sb.Append(FirstModel[j].ToString() + "=" + "\"" + DataRow[i][j].ToString() + "\"" + ",");
                    }
                    catch (Exception)
                    {

                        sb.Append(FirstModel[j].ToString() + "=" + "\"" + string.Empty + "\"" + ",");
                    }
                  
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
            List<string> NoFirstList = new List<string>();
            var list = richboxToList();
            var fiterList = getListString();
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

                if (i != 0 && !string.IsNullOrEmpty(list[i]))
                {
                    NoFirstList.Add(list[i]);
                }
            }

            vm.FiterList = fiterList;
            vm.AllColumns = list;
            vm.Detail = this.txtDetail.Text.Trim().TrimStart();
            vm.Prefix = this.txtPrefix.Text.Trim().TrimStart();
            vm.ModuleName = this.txtModule.Text.Trim().TrimStart();
            vm.FKID = this.txtFKID.Text.Trim().TrimStart();
            vm.FKTable = this.txtChildTable.Text.Trim().TrimStart();
            vm.OtherRows = datalist;
            vm.NoFirstList = NoFirstList;
            // 初始话模板路径
            vm.input_template_createtable = System.Environment.CurrentDirectory.ToString() + @"\Template\PG\CreateTable.txt";
            vm.input_template_fktable = System.Environment.CurrentDirectory.ToString() + @"\Template\PG\FKTable.txt";
            vm.input_template_truetable = System.Environment.CurrentDirectory.ToString() + @"\Template\PG\TrueTable.txt";
            vm.IsIInsertTestData = this.IsIInsertTestData.Checked;
            this.richTemplate.Text = LocalFileHelper.FileToString(vm.input_template_createtable);
            this.richFK.Text = LocalFileHelper.FileToString(vm.input_template_fktable);

            StringBuilder sb_pgcol = new StringBuilder();
            StringBuilder sb_pgdata1 = new StringBuilder();
            StringBuilder sb_pgdata2 = new StringBuilder();
            StringBuilder sb_pgdata3 = new StringBuilder();
            StringBuilder sb_pgdata4 = new StringBuilder();
            StringBuilder sb_pgdata5 = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {

                var Item = list[i].ToString().Trim();
                if (i == list.Count - 1)
                {
                    sb_pgcol.Append($"\"{Item}\"");
                    sb_pgdata1.Append($"'{1}'");
                    sb_pgdata2.Append($"'{2}'");
                    sb_pgdata3.Append($"'{3}'");
                    sb_pgdata4.Append($"'{4}'");
                    sb_pgdata5.Append($"'{5}'");

                }
                else
                {
                    sb_pgcol.Append($"\"{Item}\",");
                    sb_pgdata1.Append($"'{1}',");
                    sb_pgdata2.Append($"'{2}',");
                    sb_pgdata3.Append($"'{3}',");
                    sb_pgdata4.Append($"'{4}',");
                    sb_pgdata5.Append($"'{5}',");
                }
            }
            vm.PGInsertColums = sb_pgcol.ToString();
            vm.PGInsertColumsData1 = sb_pgdata1.ToString();
            vm.PGInsertColumsData2 = sb_pgdata2.ToString();
            vm.PGInsertColumsData3 = sb_pgdata3.ToString();
            vm.PGInsertColumsData4 = sb_pgdata4.ToString();
            vm.PGInsertColumsData5 = sb_pgdata5.ToString();
            return vm;
        }

        public List<Control> getControlList()
        {
            List<Control> list = new List<Control>();
            list.Add(this.txt_sbname);
            list.Add(this.rich_sb_old);
            list.Add(this.rich_sb_new);
            list.Add(this.richReplace);
            list.Add(this.txtModule);
            list.Add(this.txtPrefix);
            list.Add(this.txtDetail);
            list.Add(this.txt_sbname);
            list.Add(this.rich_sb_old);
            list.Add(this.rich_sb_new);
            list.Add(this.txtDetail);
            list.Add(this.txtModule);
            list.Add(this.txtPrefix);
            list.Add(this.txtChildTable);
            list.Add(this.txtFKID);
            list.Add(this.IsIInsertTestData);
            list.Add(this.txtReplace1);
            list.Add(this.txtReplace1);
            list.Add(this.txtReplace2);
            list.Add(this.txtReplace3);
            list.Add(this.txtReplace4);
            list.Add(this.txtReplace5);
            list.Add(this.txtReplace6);
            return list;
        }

        private void CodeMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            FileOperate.saveAllForms(getControlList());
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

            if (vm.FirstRow != null)
            {
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

            }

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

        private void btnSQLIN_Click(object sender, EventArgs e)
        {
            var list = richboxToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"(");
            for (int i = 0; i < list.Count; i++)
            {
                var Item = list[i];
                if (i == list.Count - 1)
                {
                    sb.AppendLine($"'{Item}'");
                }
                else
                {
                    sb.AppendLine($"'{Item}',");
                }
            }
            sb.AppendLine($")");
            this.rich_sb_new.Text = sb.ToString();
        }

        private void SqlLiteSave(object sender, EventArgs e)
        {
            SaveSQLLiteMethod();
        }

        private void SqlLiteGet(object sender, EventArgs e)
        {
            GetSQLLiteMethod();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.rich_sb_old.Text = LocalFileHelper.FileToString(@"C:\Users\HongZhong\Desktop\response_a9b239c8-9655-425d-90f9-e9872012de19.json");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string inputText = this.rich_sb_old.Text;
            Regex regex = new Regex(@"card_group([\s\S]*?)},", RegexOptions.Multiline);
            var result = regex.Matches(inputText);
            List<List<string>> matchResults = new List<List<string>>();
            foreach (var item in result)
            {
                var match = item as Match;
                List<string> matchGroups = new List<string>();
                for (int i = 0; i < match.Groups.Count; i++)
                {
                    matchGroups.Add(match.Groups[i].Value);
                }
                matchResults.Add(matchGroups);
            }
            var a = matchResults;

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            generatePGSQL();
        }

        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{

        //}

        private void button15_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            LocalFileHelper.WriteText(constRichTextBoxModel.input_template_createtable, this.richTemplate.Text);
            //LocalFileHelper.FileToString(constRichTextBoxModel.input_template_createtable);

            LocalFileHelper.WriteText(constRichTextBoxModel.input_template_fktable, this.richFK.Text);
            //LocalFileHelper.FileToString(constRichTextBoxModel.input_template_createtable);

        }

        private void ReplaceALL(string Type)
        {
            //var Template_File = LocalFileHelper.FileToString(constRichTextBoxModel.input_template_createtable, Encoding.UTF8);
            //1.设置模板路径
            string Template_File = string.Empty;
            string TrueTableModel = string.Empty;
            if (Type == ConstTemplateType.CreateTable)
            {
                Template_File = LocalFileHelper.FileToString(constRichTextBoxModel.input_template_createtable, Encoding.UTF8);
            }
            if (Type == ConstTemplateType.FKTable)
            {
                Template_File = LocalFileHelper.FileToString(constRichTextBoxModel.input_template_createtable, Encoding.UTF8);
                Template_File = Template_File + "\r\n";
                Template_File = Template_File + LocalFileHelper.FileToString(constRichTextBoxModel.input_template_fktable, Encoding.UTF8);
            }
            if (Type == ConstTemplateType.TrueTable)
            {
                Template_File = LocalFileHelper.FileToString(constRichTextBoxModel.input_template_truetable, Encoding.UTF8);
                //Template_File = Template_File + "\r\n";
                //Template_File = Template_File + LocalFileHelper.FileToString(constRichTextBoxModel.input_template_truetable, Encoding.UTF8);

            }


            //2.设置通用替换  单个字符替换
            Template_File = Template_File.Replace("$Prefix$", constRichTextBoxModel.Prefix);
            Template_File = Template_File.Replace("$ModuleName$", constRichTextBoxModel.ModuleName);
            Template_File = Template_File.Replace("$Detail$", constRichTextBoxModel.Detail);
            Template_File = Template_File.Replace("$PGInsertColums$", constRichTextBoxModel.PGInsertColums);
            Template_File = Template_File.Replace("$FKTable$", constRichTextBoxModel.FKTable);
            Template_File = Template_File.Replace("$FKID$", constRichTextBoxModel.FKID);
            Template_File = Template_File.Replace("$FirstRow$", constRichTextBoxModel.FirstRow[0]);

            //3.自定义方法 Testing Data
            if (Type == ConstTemplateType.CreateTable || Type == ConstTemplateType.FKTable)
            {
                if (constRichTextBoxModel.IsIInsertTestData == true)
                {
                    Template_File = Template_File.Replace("$IsIInsertTestDataStart$", "--Insert test data start");
                    Template_File = Template_File.Replace("$IsIInsertTestDataEnd$", "--Insert test data end");
                }
                else
                {
                    string removeTxt = Template_File.Substring(Template_File.IndexOf("$IsIInsertTestDataStart$") + "$IsIInsertTestDataStart$".Length, Template_File.IndexOf("$IsIInsertTestDataEnd$") - Template_File.IndexOf("$IsIInsertTestDataStart$") - "$IsIInsertTestDataStart$".Length);
                    Template_File = Template_File.Replace(removeTxt, "");
                    Template_File = Template_File.Replace("$IsIInsertTestDataStart$", "");
                    Template_File = Template_File.Replace("$IsIInsertTestDataEnd$", "");
                }

                StringBuilder Sb_For_Start = new StringBuilder();
                string For_Col_Start = Template_File.Substring(Template_File.IndexOf("$For_Col_Start$") + "$For_Col_Start$".Length, Template_File.IndexOf("$For_Col_End$") - Template_File.IndexOf("$For_Col_Start$") - "$For_Col_Start$".Length);
                if (!string.IsNullOrEmpty(For_Col_Start))
                {
                    foreach (var item in constRichTextBoxModel.AllColumns)
                    {
                        var Single = "\"" + item.ToString() + "\"";
                        Sb_For_Start.AppendLine($"{Single}" + For_Col_Start);
                    }
                }
                Template_File = Template_File.Replace("$For_Col_Start$" + For_Col_Start + "$For_Col_End$", Sb_For_Start.ToString());
                Template_File = Template_File.Replace("$PGInsertColumsData1$", constRichTextBoxModel.PGInsertColumsData1);
                Template_File = Template_File.Replace("$PGInsertColumsData2$", constRichTextBoxModel.PGInsertColumsData2);
                Template_File = Template_File.Replace("$PGInsertColumsData3$", constRichTextBoxModel.PGInsertColumsData3);
                Template_File = Template_File.Replace("$PGInsertColumsData4$", constRichTextBoxModel.PGInsertColumsData4);
                Template_File = Template_File.Replace("$PGInsertColumsData5$", constRichTextBoxModel.PGInsertColumsData5);

            }

            if (Type == ConstTemplateType.TrueTable)
            {
                StringBuilder sb_TrueTableModel = new StringBuilder();
                foreach (var item in constRichTextBoxModel.NoFirstList)
                {
                    if (item.ToString().ToLower().IndexOf("string") > -1)
                    {
                        sb_TrueTableModel.AppendLine($@"
""{item.ToString().Replace("string", "").TrimStart().TrimEnd()}"" character varying(255) COLLATE pg_catalog.""default"",
");
                    }
                    else if (item.ToString().ToLower().IndexOf("datetime") > -1)
                    {
                        sb_TrueTableModel.AppendLine($@"
""{item.ToString().Replace("DateTime", "").Replace("datetime", "").TrimStart().TrimEnd()}"" timestamp(6) without time zone,
");
                    }
                    else
                    {
                        sb_TrueTableModel.AppendLine($@"
""{item.ToString().Replace("string", "").TrimStart().TrimEnd()}"" character varying(255) COLLATE pg_catalog.""default"",
");

                    }

                }
                TrueTableModel = sb_TrueTableModel.ToString().TrimEnd().TrimEnd(',');
                Template_File = Template_File.Replace("$TrueTableModel$", TrueTableModel);
            }



            //通用方法
            this.richReplace.Text = Template_File;
            this.rich_sb_new.Text = Template_File;


        }

        private void ReplaceView_Click(object sender, EventArgs e)
        {
            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            ReplaceALL(ConstTemplateType.CreateTable);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_2(object sender, EventArgs e)
        {
            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            ReplaceALL(ConstTemplateType.FKTable);
        }

        private void btnPivot_Click(object sender, EventArgs e)
        {
            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            var list = constRichTextBoxModel.FirstRow;
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(ReplaceChar(item.ToString()));
            }
            this.rich_sb_new.Text = sb.ToString();
        }

        public string ReplaceChar(string str)
        {
            string temp = string.Empty;
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            str = rgx.Replace(str, "");
            str = str.Replace("-", "");
            str = str.Replace(" ", "");
            temp = str;
            if (temp.Length >= 2)
            {
                temp = str.First().ToString().ToUpper() + str.Substring(1);
            }
            return temp;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            var list = constRichTextBoxModel.AllColumns;
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                var temp = ReplaceChar(item.ToString());
                if (!string.IsNullOrEmpty(temp))
                {
                    sb.AppendLine(temp);
                }
            }
            this.rich_sb_new.Text = sb.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            string temp_old = this.rich_sb_old.Text;
            string temp_new = this.rich_sb_new.Text;
            this.rich_sb_old.Text = temp_new;
            this.rich_sb_new.Text = temp_old;
        }

        private void ModelToPGSQL_Click(object sender, EventArgs e)
        {

            //PropertyInfo[] pro = this.rich_sb_old.Text.ToString().GetType().GetProperties();
            //var a = DesToString(this.rich_sb_old.Text.ToString());
            //List<PropertyInfo> idlist = GetIdProperty(pro);
            ////要更新的数据表
            //string table = FindPropertyInfoValue(obj, "TableName").ToString();

            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            var list = constRichTextBoxModel.AllColumns;
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                var temp = ReplaceCharTwo(item.ToString());
                temp = temp.TrimEnd().TrimStart();
                temp = temp.Replace("\r\n", string.Empty);
                if (!string.IsNullOrEmpty(temp))
                {
                    sb.AppendLine(temp);
                }
            }
            this.rich_sb_new.Text = sb.ToString();

        }
        public string ReplaceCharTwo(string str)
        {
            str = str.Replace("public", "");
            str = str.Replace("class", "");
            //str = str.Replace("", "");
            string temp = string.Empty;
            Regex rgx = new Regex("[^a-zA-Z0-9 -_]");
            str = rgx.Replace(str, "");
            str = str.Replace("-", "");
            str = str.Replace("\r\n", string.Empty); //
            str = str.TrimEnd().TrimStart();
            str = str.Replace("\n", string.Empty);
            if (!string.IsNullOrEmpty(this.txtReplace1.Text))
            {
                str = str.Replace(this.txtReplace1.Text.Trim(), "");
            }
            if (!string.IsNullOrEmpty(this.txtReplace2.Text))
            {
                str = str.Replace(this.txtReplace2.Text.Trim(), "");
            }
            if (!string.IsNullOrEmpty(this.txtReplace3.Text))
            {
                str = str.Replace(this.txtReplace3.Text.Trim(), "");
            }
            if (!string.IsNullOrEmpty(this.txtReplace4.Text))
            {
                str = str.Replace(this.txtReplace4.Text.Trim(), "");
            }
            if (!string.IsNullOrEmpty(this.txtReplace5.Text))
            {
                str = str.Replace(this.txtReplace5.Text.Trim(), "");
            }
            if (!string.IsNullOrEmpty(this.txtReplace6.Text))
            {
                str = str.Replace(this.txtReplace6.Text.Trim(), "");
            }

            //str = str.Replace(" ", "");
            temp = str;
            //if (temp.Length >= 2)
            //{
            //    temp = str.First().ToString().ToUpper() + str.Substring(1);
            //}
            return temp;

        }

        public object DesToString(string modelstr)
        {
            if (modelstr == "") return null;
            object model = new object();
            Type type = model.GetType();//assembly.GetType("Reflect_test.PurchaseOrderHeadManageModel", true, true); //命名空间名称 + 类名  

            //创建类的实例  
            //object obj = Activator.CreateInstance(type, true);

            Dictionary<string, object> dict = new Dictionary<string, object>();

            //获取公共属性  
            PropertyInfo[] Propertys = type.GetProperties();
            object[] objs = modelstr.Split('_');
            //foreach (object obj in objs)
            //{
            //    object[] obj1 = obj.ToString().Split('|');
            //    dict[obj1[0].ToString()] = obj1[1];
            //}
            for (int i = 0; i < Propertys.Length; i++)
            {
                string p_type = Propertys[i].PropertyType.ToString().ToLower();
                if (dict[Propertys[i].Name].ToString() == "") dict[Propertys[i].Name] = null;
                // Propertys[i].SetValue(Propertys[i], i, null); //设置值  
                PropertyInfo pi = type.GetProperty(Propertys[i].Name);
                object value = null;
                if (p_type.Contains("decimal"))
                {
                    if (dict[Propertys[i].Name] != null)
                        value = Convert.ToDecimal(dict[Propertys[i].Name]);
                }
                else if (p_type.Contains("int32"))
                {
                    if (dict[Propertys[i].Name] != null)
                        value = Convert.ToInt32(dict[Propertys[i].Name]);
                }
                else if (p_type.Contains("int64"))
                {
                    if (dict[Propertys[i].Name] != null)
                        value = Convert.ToInt64(dict[Propertys[i].Name]);
                }
                else if (p_type.Contains("datetime") || p_type.Contains("date"))
                {
                    if (dict[Propertys[i].Name] != null)
                        value = Convert.ToDateTime(dict[Propertys[i].Name]);
                }
                else
                {
                    value = dict[Propertys[i].Name];
                }
                pi.SetValue(model, value, null);

                //Console.WriteLine("属性名：{0},类型：{1}", Propertys[i].Name, Propertys[i].PropertyType);
            }

            return model;
        }

        private void btnToPGSQL_Click(object sender, EventArgs e)
        {
            constRichTextBoxModel = this.getRichTextBoxToVM(); //重新加载
            ReplaceALL(ConstTemplateType.TrueTable);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = this.rich_sb_new.Text.Replace("\"\"", "\"");
            this.rich_sb_old.Text = this.rich_sb_old.Text.Replace("\"\"", "\"");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text= this.rich_sb_new.Text.Replace("\"", "\"\"");
            this.rich_sb_old.Text=this.rich_sb_old.Text.Replace("\"", "\"\"");

        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.rich_sb_new.Text = this.rich_sb_new.Text.Replace("\"", "");
            this.rich_sb_old.Text = this.rich_sb_old.Text.Replace("\"", "");
        }

        ///字符串转为对象
        //public List<Object> GetListFromString(string str)
        //{
        //    try
        //    {
        //        byte[] array = Encoding.UTF8.GetBytes(str);
        //        MemoryStream stream = new MemoryStream(array);
        //        StreamReader reader = new StreamReader(stream);


        //        List<Object> newList = new List<Object>();
        //        Object newModel;
        //        int line = 0;
        //        string lineStr;
        //        while ((lineStr = reader.ReadLine()) != null)
        //        {
        //            line++;
        //            if (line == 1) continue; //跳过第一行                    
        //            string[] fields = lineStr.Split(new char[] { '|' });
        //            newModel = new NewModel();
        //            newModel.CustomerName = fields[0].Trim();
        //            newModel.IDNo = fields[1].Trim();
        //            newModel.Address = fields[2].Trim();
        //            newList.Add(newModel);
        //        }
        //        return newList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("字符串解析异常：throw:" + ex.Message.ToString());
        //        throw ex;
        //    }
        //}
    }

    public class RichTextBoxModel
    {

        public List<string> FirstRow { get; set; }

        public List<string> FiterList { get; set; }
        public List<List<string>> OtherRows { get; set; }
        public List<string> AllColumns { get; set; }

        public List<string> NoFirstList { get; set; }

        public string Prefix { get; set; }
        public string Detail { get; set; }
        public string ModuleName { get; set; }

        public string input_template_createtable { get; set; }

        public string input_template_fktable { get; set; }

        public string input_template_truetable { get; set; }

        public string PGInsertColums { get; set; }

        public string PGInsertColumsData1 { get; set; }
        public string PGInsertColumsData2 { get; set; }
        public string PGInsertColumsData3 { get; set; }
        public string PGInsertColumsData4 { get; set; }
        public string PGInsertColumsData5 { get; set; }
        public string FKTable { get; set; }
        public string FKID { get; set; }

        public bool IsIInsertTestData { get; set; }

    }

    public class Settings
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string CreateDate { get; set; }
    }

}
