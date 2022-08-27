using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Roch.DomainModel;
using Roch.Framework;
namespace Roch.CodeTool
{
    public partial class MyCode : Form
    {
        public MyCode()
        {
            InitializeComponent();
        }


        private void MyCode_Load(object sender, EventArgs e)
        {
            bind_list_View();
        }

        #region MyRegion

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var random = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ssss");
            var curren_dir = LocalFileHelper.LocalPath + "/MyCode";
            var curren_file = LocalFileHelper.LocalPath + "/MyCode/" + random + ".txt";
            var config_file = LocalFileHelper.LocalPath + "/MyCode/" + random + ".jason";

            LocalFileHelper.CreateDirectory(curren_dir);
            LocalFileHelper.CreateFile(curren_file);
            LocalFileHelper.CreateFile(config_file);

            

            bind_list_View();
        }

        public void bind_list_View()
        {
            listViewTables.GridLines = true;//显示各个记录的分隔线 

            listViewTables.FullRowSelect = true;//要选择就是一行 
            listViewTables.View = View.Details;//定义列表显示的方式 
            listViewTables.Scrollable = true;//需要时候显示滚动条 
            listViewTables.MultiSelect = false; // 不可以多行选择 
            listViewTables.HeaderStyle = ColumnHeaderStyle.Clickable;


            listViewTables.GridLines = true;//显示各个记录的分隔线 
            listViewTables.FullRowSelect = true;//要选择就是一行 
            listViewTables.View = View.Details;//定义列表显示的方式 
            listViewTables.Scrollable = true;//需要时候显示滚动条 
            listViewTables.MultiSelect = false; // 不可以多行选择 
            listViewTables.HeaderStyle = ColumnHeaderStyle.Clickable;

            // 针对数据库的字段名称，建立与之适应显示表头
            listViewTables.Clear();
            listViewTables.Columns.Add("序号", 50, HorizontalAlignment.Left);
            listViewTables.Columns.Add("名称", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("模板", 180, HorizontalAlignment.Left);

            listViewTables.Visible = true;


            List<string> list = new List<string>();

            DirectoryInfo theFolder = new DirectoryInfo(LocalFileHelper.LocalPath + "/MyCode");
            FileInfo[] dirFile = theFolder.GetFiles();
            //遍历文件夹
            foreach (FileInfo NextFile in dirFile)
            {
                if (NextFile.Extension == ".txt")
                {
                    list.Add(NextFile.Name);
                }


            }


            for (int i = 0; i < list.Count; i++)
            {
                var item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = i.ToString();
                var filepath = FileOperate.readFile((LocalFileHelper.LocalPath + "/MyCode/"+list[i].ToString() + ".jason"));
                item.SubItems.Add(filepath);
                item.SubItems.Add(list[i].ToString());

                listViewTables.Items.Add(item);
            }




        }

        private void listViewTables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listViewTables.SelectedItems.Count > 0)
            {

                var path = LocalFileHelper.LocalPath + "MyCode/" + listViewTables.SelectedItems[0].SubItems[2].Text;
                this.richTextBox1.LoadFile(path, RichTextBoxStreamType.PlainText);

            }


        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            FileOperate.saveRichTextFile(this.richTextBox1, LocalFileHelper.LocalPath + "MyCode/" + listViewTables.SelectedItems[0].SubItems[1].Text);

        }

        private void button4_Click(object sender, System.EventArgs e)
        {


            if (listViewTables.SelectedItems.Count > 0)
            {

                var path = LocalFileHelper.LocalPath + "MyCode/" + listViewTables.SelectedItems[0].SubItems[1].Text;
                LocalFileHelper.DeleteFile(path);
                bind_list_View();
            }
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            var str = this.richTextBox1.Text.Trim();

        }


    }
}
