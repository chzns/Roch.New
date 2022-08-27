using Roch.DomainModel;
using Roch.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Roch.CodeTool
{
    public partial class FrmItemModel : Form
    {
        public FrmItemModel()
        {
            InitializeComponent();
        }


        //生成测试数据
        private void button2_Click(object sender, EventArgs e)
        {
            List<Item_Model> list_Item_Model = new List<Item_Model>();
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                Item_Model model_Item_Model = new Item_Model();
                //model_Item_Model.Item_Cloumn = "Data";
                model_Item_Model.Item_1 = i.ToString();
                model_Item_Model.Item_2 = "Item_2" + ":" + i.ToString();
                model_Item_Model.Item_3 = r.Next(20, 30).ToString();
                model_Item_Model.Item_4 = r.Next(30, 40).ToString();
                model_Item_Model.Item_5 = r.Next(40, 50).ToString();
                model_Item_Model.Item_6 = r.Next(60, 70).ToString();
                model_Item_Model.Item_7 = r.Next(60, 70).ToString();
                model_Item_Model.Item_8 = r.Next(60, 70).ToString();
                model_Item_Model.Item_9 = r.Next(60, 70).ToString();
                model_Item_Model.Item_10 = r.Next(60, 70).ToString();
                model_Item_Model.Item_11 = r.Next(60, 70).ToString();
                model_Item_Model.Item_12 = r.Next(60, 70).ToString();


                model_Item_Model.Item_13 = r.Next(60, 70).ToString();


                model_Item_Model.Item_14 = r.Next(60, 70).ToString();


                model_Item_Model.Item_15 = r.Next(60, 70).ToString();


                model_Item_Model.Item_16 = r.Next(60, 70).ToString();


                model_Item_Model.Item_17 = r.Next(60, 70).ToString();


                model_Item_Model.Item_18 = r.Next(60, 70).ToString();


                model_Item_Model.Item_19 = r.Next(60, 70).ToString();


                model_Item_Model.Item_20 = r.Next(60, 70).ToString();


                model_Item_Model.Item_21 = r.Next(60, 70).ToString();


                model_Item_Model.Item_22 = r.Next(60, 70).ToString();


                model_Item_Model.Item_23 = r.Next(60, 70).ToString();


                model_Item_Model.Item_24 = r.Next(60, 70).ToString();


                model_Item_Model.Item_25 = r.Next(60, 70).ToString();


                model_Item_Model.Item_26 = r.Next(60, 70).ToString();


                model_Item_Model.Item_27 = r.Next(60, 70).ToString();


                model_Item_Model.Item_28 = r.Next(60, 70).ToString();


                model_Item_Model.Item_29 = r.Next(60, 70).ToString();


                model_Item_Model.Item_30 = r.Next(60, 70).ToString();
                model_Item_Model.Item_31 = r.Next(60, 70).ToString();
                model_Item_Model.Item_32 = r.Next(60, 70).ToString();
                model_Item_Model.Item_33 = r.Next(60, 70).ToString();
                model_Item_Model.Item_34 = r.Next(60, 70).ToString();
                model_Item_Model.Item_35 = r.Next(60, 70).ToString();
                model_Item_Model.Item_36 = r.Next(60, 70).ToString();
                model_Item_Model.Item_37 = r.Next(60, 70).ToString();
                model_Item_Model.Item_38 = r.Next(60, 70).ToString();
                model_Item_Model.Item_39 = r.Next(60, 70).ToString();
                model_Item_Model.Item_40 = r.Next(60, 70).ToString();


                list_Item_Model.Add(model_Item_Model);

            }

            list_Item_Model[0].Item_Cloumn = "Cloumn";


            list_Item_Model[0].Item_1 = "Cloumn1";


            list_Item_Model[0].Item_2 = "Cloumn2";


            list_Item_Model[0].Item_3 = "Cloumn3";


            list_Item_Model[0].Item_4 = "Cloumn4";


            list_Item_Model[0].Item_5 = "Cloumn5";


            list_Item_Model[0].Item_6 = "Cloumn6";


            list_Item_Model[0].Item_7 = "Cloumn7";


            list_Item_Model[0].Item_8 = "Cloumn8";


            list_Item_Model[0].Item_9 = "Cloumn9";


            list_Item_Model[0].Item_10 = "Cloumn10";


            list_Item_Model[0].Item_11 = "Cloumn11";


            list_Item_Model[0].Item_12 = "Cloumn12";


            list_Item_Model[0].Item_13 = "Cloumn13";


            list_Item_Model[0].Item_14 = "Cloumn14";


            list_Item_Model[0].Item_15 = "Cloumn15";


            list_Item_Model[0].Item_16 = "Cloumn16";


            list_Item_Model[0].Item_17 = "Cloumn17";


            list_Item_Model[0].Item_18 = "Cloumn18";


            list_Item_Model[0].Item_19 = "Cloumn19";


            list_Item_Model[0].Item_20 = "Cloumn20";


            list_Item_Model[0].Item_21 = "Cloumn21";


            list_Item_Model[0].Item_22 = "Cloumn22";


            list_Item_Model[0].Item_23 = "Cloumn23";


            list_Item_Model[0].Item_24 = "Cloumn24";


            list_Item_Model[0].Item_25 = "Cloumn25";


            list_Item_Model[0].Item_26 = "Cloumn26";


            list_Item_Model[0].Item_27 = "Cloumn27";


            list_Item_Model[0].Item_28 = "Cloumn28";


            list_Item_Model[0].Item_29 = "Cloumn29";


            list_Item_Model[0].Item_30 = "Cloumn30";
            list_Item_Model[0].Item_31 = "Cloumn31";
            list_Item_Model[0].Item_32 = "Cloumn32";
            list_Item_Model[0].Item_33 = "Cloumn33";
            list_Item_Model[0].Item_34 = "Cloumn34";
            list_Item_Model[0].Item_35 = "Cloumn35";
            list_Item_Model[0].Item_36 = "Cloumn36";
            list_Item_Model[0].Item_37 = "Cloumn37";
            list_Item_Model[0].Item_38 = "Cloumn38";
            list_Item_Model[0].Item_39 = "Cloumn39";
            list_Item_Model[0].Item_40 = "Cloumn40";




            DataTable dt = list_Item_Model.ToDataTable<Item_Model>();
            ExcelExtensions.ExportExcelWithAspose(dt, ConstConstants.Item_Model_Path);
            Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);//复制RTF数据到剪贴板
            System.Diagnostics.Process.Start(ConstConstants.Item_Model_Path);
        }

        public void bind_list_View(List<Item_Model> list_Item_Model)
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
            listViewTables.Columns.Add("Item0", 50, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item1", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item2", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item3", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item4", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item5", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item6", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item7", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item8", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item9", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item10", 180, HorizontalAlignment.Left);
            listViewTables.Columns.Add("Item11", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item12", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item13", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item14", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item15", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item16", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item17", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item18", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item19", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item20", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item21", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item22", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item23", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item24", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item25", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item26", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item27", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item28", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item29", 180, HorizontalAlignment.Left);

            listViewTables.Columns.Add("Item30", 180, HorizontalAlignment.Left);


            listViewTables.Visible = true;

            for (int i = 0; i < list_Item_Model.Count; i++)
            {
                var item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = (i + 1).ToString();
                item.SubItems.Add(list_Item_Model[i].Item_Cloumn.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_1.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_2.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_3.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_4.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_5.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_6.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_7.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_8.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_9.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_10.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_11.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_12.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_13.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_14.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_15.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_16.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_17.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_18.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_19.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_20.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_21.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_22.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_23.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_24.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_25.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_26.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_27.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_28.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_29.ToString());
                item.SubItems.Add(list_Item_Model[i].Item_30.ToString());
                //var filepath = FileOperate.readFile((LocalFileHelper.LocalPath + "/MyCode/" + list[i].ToString() + ".jason"));
                //item.SubItems.Add(filepath);
                //item.SubItems.Add(list[i].ToString());
                listViewTables.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            List<Item_Model> list_Item_Model = ExcelToList.Item_Model_ExcelToModel(ConstConstants.Item_Model_Path);
            bind_list_View(list_Item_Model);

            //Main函数
            sb.AppendLine(MainString());

            //输出数据
            sb.AppendLine(ExportString());

            //静态模型
            sb.AppendLine(StaticModelString());

            //增加DataTable类
            sb.AppendLine(DataTableString());

            //增加SplitString()函数
            sb.AppendLine(SplitString());

            //静态测试数据ListString
            sb.AppendLine(ListString(list_Item_Model));

            //赋值
            this.richTextBox1.Text = sb.ToString();

            Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);//复制RTF数据到剪贴板

        }

        public string ListString(List<Item_Model> list_Item_Model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class TestData".ToString());
            sb.AppendLine("{".ToString());
            sb.AppendLine("    public static List<Item_Model> GetTestData()".ToString());
            sb.AppendLine("    {".ToString());
            sb.AppendLine("        List<Item_Model> list_Item_Model = new List<Item_Model>();".ToString());

            #region 动态
            for (int i = 0; i < list_Item_Model.Count; i++)
            {
                sb.AppendLine("//" + (i + 1).ToString().ToString());
                sb.AppendLine("{".ToString());
                sb.AppendLine("Item_Model model_Item_Model = new Item_Model();".ToString());
                sb.AppendLine("model_Item_Model.Item_Cloumn = " + "\"" + list_Item_Model[i].Item_Cloumn.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_1 = " + "\"" + list_Item_Model[i].Item_1.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_2 = " + "\"" + list_Item_Model[i].Item_2.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_3 = " + "\"" + list_Item_Model[i].Item_3.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_4 = " + "\"" + list_Item_Model[i].Item_4.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_5 = " + "\"" + list_Item_Model[i].Item_5.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_6 = " + "\"" + list_Item_Model[i].Item_6.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_7 = " + "\"" + list_Item_Model[i].Item_7.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_8 = " + "\"" + list_Item_Model[i].Item_8.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_9 = " + "\"" + list_Item_Model[i].Item_9.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_10 = " + "\"" + list_Item_Model[i].Item_10.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_11 = " + "\"" + list_Item_Model[i].Item_11.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_12 = " + "\"" + list_Item_Model[i].Item_12.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_13 = " + "\"" + list_Item_Model[i].Item_13.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_14 = " + "\"" + list_Item_Model[i].Item_14.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_15 = " + "\"" + list_Item_Model[i].Item_15.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_16 = " + "\"" + list_Item_Model[i].Item_16.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_17 = " + "\"" + list_Item_Model[i].Item_17.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_18 = " + "\"" + list_Item_Model[i].Item_18.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_19 = " + "\"" + list_Item_Model[i].Item_19.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_20 = " + "\"" + list_Item_Model[i].Item_20.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_21 = " + "\"" + list_Item_Model[i].Item_21.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_22 = " + "\"" + list_Item_Model[i].Item_22.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_23 = " + "\"" + list_Item_Model[i].Item_23.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_24 = " + "\"" + list_Item_Model[i].Item_24.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_25 = " + "\"" + list_Item_Model[i].Item_25.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_26 = " + "\"" + list_Item_Model[i].Item_26.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_27 = " + "\"" + list_Item_Model[i].Item_27.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_28 = " + "\"" + list_Item_Model[i].Item_28.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_29 = " + "\"" + list_Item_Model[i].Item_29.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_30 = " + "\"" + list_Item_Model[i].Item_30.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_31 = " + "\"" + list_Item_Model[i].Item_31.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_32 = " + "\"" + list_Item_Model[i].Item_32.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_33 = " + "\"" + list_Item_Model[i].Item_33.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_34 = " + "\"" + list_Item_Model[i].Item_34.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_35 = " + "\"" + list_Item_Model[i].Item_35.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_36 = " + "\"" + list_Item_Model[i].Item_36.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_37 = " + "\"" + list_Item_Model[i].Item_37.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_38 = " + "\"" + list_Item_Model[i].Item_38.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_39 = " + "\"" + list_Item_Model[i].Item_39.ToString() + "\"" + ";".ToString());
                sb.AppendLine("model_Item_Model.Item_40 = " + "\"" + list_Item_Model[i].Item_40.ToString() + "\"" + ";".ToString());

                sb.AppendLine("list_Item_Model.Add(model_Item_Model);".ToString());
                sb.AppendLine("}".ToString());

            }
            #endregion
            sb.AppendLine("        return list_Item_Model;".ToString());
            sb.AppendLine("    }".ToString());
            sb.AppendLine("}".ToString());

            return sb.ToString();

        }


        public string MainString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("void Main()".ToString());
            sb.AppendLine("{".ToString());
            sb.AppendLine("var test_db=TestData.GetTestData();".ToString());
            sb.AppendLine("var filer_db=test_db.Select(".ToString());
            sb.AppendLine("               m => new ".ToString());
            sb.AppendLine("               {".ToString());
            sb.AppendLine("                  Item_Cloumn = m.Item_Cloumn.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_1 = m.Item_1.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_2 = m.Item_2.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_3 = m.Item_3.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_4 = m.Item_4.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_5 = m.Item_5.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_6 = m.Item_6.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_7 = m.Item_7.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_8 = m.Item_8.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_9 = m.Item_9.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_10 = m.Item_10.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_11 = m.Item_11.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_12 = m.Item_12.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_13 = m.Item_13.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_14 = m.Item_14.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_15 = m.Item_15.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_16 = m.Item_16.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_17 = m.Item_17.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_18 = m.Item_18.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_19 = m.Item_19.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_20 = m.Item_20.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_21 = m.Item_21.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_22 = m.Item_22.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_23 = m.Item_23.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_24 = m.Item_24.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_25 = m.Item_25.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_26 = m.Item_26.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_27 = m.Item_27.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_28 = m.Item_28.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_29 = m.Item_29.TrimStart().TrimEnd(),".ToString());


            sb.AppendLine("                   Item_30 = m.Item_30.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_31 = m.Item_31.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_32 = m.Item_32.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_33 = m.Item_33.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_34 = m.Item_34.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_35 = m.Item_35.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_36 = m.Item_36.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_37 = m.Item_37.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_38 = m.Item_38.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_39 = m.Item_39.TrimStart().TrimEnd(),".ToString());
            sb.AppendLine("                   Item_40 = m.Item_40.TrimStart().TrimEnd()".ToString());

            sb.AppendLine("               }).ToList();".ToString());
            return sb.ToString();
        }

        public string StaticModelString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class Item_Model".ToString());
            sb.AppendLine("    {".ToString());
            sb.AppendLine("        public string Item_Cloumn { get; set; }".ToString());
            sb.AppendLine("        public string Item_1 { get; set; }".ToString());
            sb.AppendLine("        public string Item_2 { get; set; }".ToString());
            sb.AppendLine("        public string Item_3 { get; set; }".ToString());
            sb.AppendLine("        public string Item_4 { get; set; }".ToString());
            sb.AppendLine("        public string Item_5 { get; set; }".ToString());
            sb.AppendLine("        public string Item_6 { get; set; }".ToString());
            sb.AppendLine("        public string Item_7 { get; set; }".ToString());
            sb.AppendLine("        public string Item_8 { get; set; }".ToString());
            sb.AppendLine("        public string Item_9 { get; set; }".ToString());
            sb.AppendLine("        public string Item_10 { get; set; }".ToString());
            sb.AppendLine("        public string Item_11 { get; set; }".ToString());
            sb.AppendLine("        public string Item_12 { get; set; }".ToString());
            sb.AppendLine("public string Item_13 { get; set; }");
            sb.AppendLine("public string Item_14 { get; set; }");
            sb.AppendLine("public string Item_15 { get; set; }");
            sb.AppendLine("public string Item_16 { get; set; }");
            sb.AppendLine("public string Item_17 { get; set; }");
            sb.AppendLine("public string Item_18 { get; set; }");
            sb.AppendLine("public string Item_19{ get; set; }");
            sb.AppendLine("public string Item_20{ get; set; }");
            sb.AppendLine("public string Item_21{ get; set; }");
            sb.AppendLine("public string Item_22{ get; set; }");
            sb.AppendLine("public string Item_23{ get; set; }");
            sb.AppendLine("public string Item_24{ get; set; }");
            sb.AppendLine("public string Item_25{ get; set; }");
            sb.AppendLine("public string Item_26{ get; set; }");
            sb.AppendLine("public string Item_27{ get; set; }");
            sb.AppendLine("public string Item_28{ get; set; }");
            sb.AppendLine("public string Item_29{ get; set; }");
            sb.AppendLine("public string Item_30{ get; set; }");
            sb.AppendLine("public string Item_31{ get; set; }");
            sb.AppendLine("public string Item_32{ get; set; }");
            sb.AppendLine("public string Item_33{ get; set; }");
            sb.AppendLine("public string Item_34{ get; set; }");
            sb.AppendLine("public string Item_35{ get; set; }");
            sb.AppendLine("public string Item_36{ get; set; }");
            sb.AppendLine("public string Item_37{ get; set; }");
            sb.AppendLine("public string Item_38{ get; set; }");
            sb.AppendLine("public string Item_39{ get; set; }");
            sb.AppendLine("public string Item_40{ get; set; }");
            sb.AppendLine("    }".ToString());
            return sb.ToString();


        }

        public string DataTableString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public static DataTable ToDataTableTow(IList list)");
            sb.AppendLine("  {");
            sb.AppendLine("            DataTable result = new DataTable();");
            sb.AppendLine("            if (list.Count > 0)");
            sb.AppendLine("            {");
            sb.AppendLine("                PropertyInfo[] propertys = list[0].GetType().GetProperties();");
            sb.AppendLine("                foreach (PropertyInfo pi in propertys)");
            sb.AppendLine("                {");
            sb.AppendLine("                    result.Columns.Add(pi.Name, pi.PropertyType);");
            sb.AppendLine("                }");
            sb.AppendLine("                for (int i = 0; i < list.Count; i++)");
            sb.AppendLine("                {");
            sb.AppendLine("                    ArrayList tempList = new ArrayList();");
            sb.AppendLine("                    foreach (PropertyInfo pi in propertys)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        object obj = pi.GetValue(list[i], null);");
            sb.AppendLine("                        tempList.Add(obj);");
            sb.AppendLine("                    }");
            sb.AppendLine("                    object[] array = tempList.ToArray();");
            sb.AppendLine("                    result.LoadDataRow(array, true);");
            sb.AppendLine("                }");
            sb.AppendLine("            }");
            sb.AppendLine("            return result;");
            sb.AppendLine("        }");
            return sb.ToString();
        }

        public string ExportString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//输出数据				   ");
            sb.AppendLine("var columns=filer_db.Where(m=>m.Item_Cloumn==\"Cloumn\").ToList<Object>();");
            sb.AppendLine("var dt=ToDataTableTow(columns).Dump();");
            sb.AppendLine("List<string> list =new List<string>();");
            sb.AppendLine("foreach(DataRow dr in dt.Rows)      ");
            sb.AppendLine("{    ");
            sb.AppendLine("   for(int i=0;i<dt.Columns.Count;i++)    ");
            sb.AppendLine("   {    ");
            sb.AppendLine("      var temp=  dr[i].ToString();    ");
            sb.AppendLine("	  if (temp.Length>0)");
            sb.AppendLine("	{");
            sb.AppendLine("		list.Add(temp);");
            sb.AppendLine("	}");
            sb.AppendLine("   }      ");
            sb.AppendLine("} ");
            sb.AppendLine("list=list.Where(m=>m.ToString().IndexOf(\"Cloumn\")<0).ToList();");
            sb.AppendLine("list =list.Select(m=>m.ToString().TrimEnd().TrimStart().Replace(\" \",\"_\").Replace(@\"/\",\"_\")).ToList<string>();");
            sb.AppendLine("list.Dump();");
            sb.AppendLine("var tempdata=filer_db.Where(m=>m.Item_Cloumn!=\"Cloumn\").Dump();");
            sb.AppendLine("StringBuilder sb = new StringBuilder();");
            sb.AppendLine("foreach (var element in tempdata)");
            sb.AppendLine("{");
            sb.AppendLine("var Item_1=element.Item_1.ToString();");
            sb.AppendLine("Split(Item_1,',',0).Dump();");
            sb.AppendLine("sb.AppendLine(Item_1);");
            sb.AppendLine("}");
            sb.AppendLine("sb.ToString().Dump();");
            sb.AppendLine("}");
            sb.AppendLine("//输出数据");
            return sb.ToString();
        }

        public string SplitString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public static string Split(string str,char c ,int index )");
            sb.AppendLine("{");
            sb.AppendLine("string re=\"空值\"; ");
            sb.AppendLine("  string[] sArray=str.Split(c); ");
            sb.AppendLine("  try");
            sb.AppendLine("  {");
            sb.AppendLine("  re=sArray[index].ToString();");
            sb.AppendLine("  }");
            sb.AppendLine("  catch");
            sb.AppendLine("  {");
            sb.AppendLine("    re=\"空值\"; ");
            sb.AppendLine("  }");
            sb.AppendLine("  return re; ");
            sb.AppendLine(" }");
          return   sb.ToString();

        }

        private void FrmItemModel_Load(object sender, EventArgs e)
        {
            this.groupBox1.Text = string.Empty;
            this.groupBox2.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConstConstants.Item_Model_Path);
        }


    }
}

//public class TestData
//{
//    public static List<Item_Model> GetTestData()
//    {
//        List<Item_Model> list_Item_Model = new List<Item_Model>();
//        {
//            Item_Model model_Item_Model = new Item_Model();
//            model_Item_Model.Item_1 = "7";
//            model_Item_Model.Item_2 = "18";
//            model_Item_Model.Item_3 = "27";
//            model_Item_Model.Item_4 = "37";
//            model_Item_Model.Item_5 = "44";
//            model_Item_Model.Item_6 = "68";
//            list_Item_Model.Add(model_Item_Model);
//        }
//        return list_Item_Model;
//    }
//}
