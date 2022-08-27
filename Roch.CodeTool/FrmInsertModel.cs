using Roch.DomainModel;
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
    public partial class FrmInsertModel : Form
    {

        public string ModelName { get; set; }
        public string ColumnStr { get; set; }
        public List<ModelClass> ModelClassList { get; set; }

        public string ModelText { get; set; }
        public FrmInsertModel()
        {
            InitializeComponent();
        }



        private void FrmInsertModel_Load(object sender, EventArgs e)
        {
            this.text_ColumnStr.Text = ColumnStr;
            this.txt_ModelName.Text = ModelName;
          

        }
 

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            //if (MessageBox.Show("是否关闭！", "提示", MessageBoxButtons.OKCancel) !=
            //DialogResult.OK)
            //{
               
            //}

            main_method();
            //e.Cancel = true;
        }

        public void main_method()
        {
            var columns = this.text_ColumnStr.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (this.ModelClassList!=null)
            {
                this.ModelClassList.Clear();
         
          
            for (int i = 0; i < columns.Count; i++)
            {
                ModelClass model_ModelClass = new ModelClass();
                model_ModelClass.TableName = this.txt_ModelName.Text;
                model_ModelClass.ColumnName = columns[i].ToString();
                model_ModelClass.DataType = String.Empty;
                model_ModelClass.Is_Identity = String.Empty;
                model_ModelClass.ColumnRemarks = String.Empty;
                model_ModelClass.ColumnType = String.Empty;
                model_ModelClass.ColumnDefaultValue = String.Empty;
                model_ModelClass.ColumnUI_ID = String.Empty;
                model_ModelClass.ColumnUI_Type = String.Empty;
                model_ModelClass.ColumnUI_DisplayName = String.Empty;
                model_ModelClass.JasonDefaultValue = String.Empty;
                model_ModelClass.Is_Null = String.Empty;
                this.ModelClassList.Add(model_ModelClass);

            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class " + this.txt_ModelName.Text + "".ToString());
            sb.AppendLine("    {".ToString());
            foreach (var item in ModelClassList)
            {
                sb.AppendLine("        public string " + item.ColumnName + " { get; set; }".ToString());
            }

            sb.AppendLine("    }".ToString());
            this.ModelText = sb.ToString();

            }

            this.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            main_method();

        }

        private void FrmInsertModel_FormClosed(object sender, FormClosedEventArgs e)
        {
            main_method();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<string> arry = this.richTextBox1.Text.Split(Environment.NewLine.ToCharArray()).ToList<string>();
            foreach (string item in arry.ToList())
            {
                //去除 空行字符
                if (string.IsNullOrEmpty(item.ToString().Trim()))
                {
                    arry.Remove(item);
                }
            }
            arry=arry.Select(m=>m.ToString().Trim().TrimStart()).ToList<string>();
            this.text_ColumnStr.Text = string.Join(",", arry);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> arry = this.richTextBox1.Text.Split(Environment.NewLine.ToCharArray()).ToList<string>();
            foreach (string item in arry.ToList())
            {
                //去除 空行字符
                if (string.IsNullOrEmpty(item.ToString().Trim()))
                {
                    arry.Remove(item);
                }
            }
            arry = arry.Select(m => m.ToString().Trim().TrimStart()).ToList<string>();
            this.text_ColumnStr.Text ="'"+ string.Join("','", arry)+"'";

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string a = "";
            a.Replace("_", " ");
            
            List<string> arry = this.richTextBox1.Text.Split(Environment.NewLine.ToCharArray()).ToList<string>();
            foreach (string item in arry.ToList())
            {
                //去除 空行字符
                if (string.IsNullOrEmpty(item.ToString().Trim()))
                {
                    arry.Remove(item);
                }
            }
            arry = arry.Select(m => m.ToString().Trim().TrimStart()).ToList<string>();

            var temp = string.Empty;
            for (int i = 0; i < arry.Count; i++)
            {
                temp = temp + "  [" + arry[i].ToString() + "] VARCHAR(50),";
                
            }
         
            temp = temp.TrimEnd(',');
          

            string sql = $@"   
     if object_id('test') is not null  
    BEGIN
       DROP TABLE test  
    END
    CREATE  TABLE  test ( ID int,  {temp})";

   
            this.text_ColumnStr.Text =sql;

        }
    }
}
