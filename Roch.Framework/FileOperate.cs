using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Roch.Framework
{
    public static class FileOperate
    {

        public static bool fileEixt(string path)//判断文件是否存在，path：文件路径
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string readFile(string path) //读取文件,path：文件路径,content：需要显示的内容，返回读取的文本
        {
            string content = string.Empty;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs, Encoding.Default);
            content = sr.ReadToEnd().Replace("?", "");
            //content = sr.ReadToEnd();
            fs.Close();
            sr.Close();
            return content;
        }
        public static string writeFile(string path, string content)//修改文件，path：文件路径，conten：需要修改的文本,返回修改后的文本
        {
            if (fileEixt(path))
            {
                FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(content);
                sw.Close();
                fs.Close();
                return content;
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.Write(content);
                sw.Close();
                fs.Close();
                return content;

            }
        }
        public static string clearFile(string path, string content)//清空文本内容 ，path：文件路径，content：文本内容
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Close();
            return content;
        }
        public static void saveFile(RichTextBox rtb)//保存文件 
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(.txt)|*.txt|rtf文件(.rtf)|*.rtf|所有文件(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                rtb.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        public static void saveRichTextFile(RichTextBox rtb, string path)//保存文件 
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件(.txt)|*.txt|rtf文件(.rtf)|*.rtf|所有文件(*.*)|*.*";
            rtb.SaveFile(path, RichTextBoxStreamType.PlainText);
        }
        public static void openFile(RichTextBox rtb)//打开文件
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(.txt)|*.txt|*.rtf文件|*.rtf|所有文件(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rtb.LoadFile(rtb.Text, RichTextBoxStreamType.RichText);

            }

        }

        public static void saveAllForms(List<Control> list)
        {
            foreach (Control c in list)//针对RichTextBox
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + txt.Name;
                    LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    writeFile(fileName, txt.Text);
                }

                if (c is System.Windows.Forms.RichTextBox)
                {
                    System.Windows.Forms.RichTextBox rich = (System.Windows.Forms.RichTextBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rich.Name;
                    LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    var txt = RichTextBoxStreamType.PlainText;
                    rich.SaveFile(fileName, txt);
                    //writeFile(fileName, txt.Text);
                }
                if (c is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton rad = (System.Windows.Forms.RadioButton)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rad.Name;
                    LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    writeFile(fileName, rad.Checked.ToString());
                }
                if (c is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox rad = (System.Windows.Forms.CheckBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rad.Name;
                    LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    writeFile(fileName, rad.Checked.ToString());
                }

            }
        }

        public static void loadAllForms(List<Control> list)
        {
            foreach (Control c in list)//针对RichTextBox
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox txt = (System.Windows.Forms.TextBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + txt.Name;
                    if (File.Exists(fileName))
                    {
                        txt.Text = readFile(fileName);
                    }

                    //LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    //writeFile(fileName, txt.Text);
                }

                if (c is System.Windows.Forms.RichTextBox)
                {
                    System.Windows.Forms.RichTextBox rich = (System.Windows.Forms.RichTextBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rich.Name;
                    if (File.Exists(fileName))
                    {
                        //rich.LoadFile(fileName, RichTextBoxStreamType.RichText);

                        rich.Text = readFile(fileName);
                    }

                    //txt.Text = readFile(fileName);
                    //LocalFileHelper.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Controls/");
                    //writeFile(fileName, txt.Text);
                }

                if (c is System.Windows.Forms.RadioButton)
                {
                    System.Windows.Forms.RadioButton rad = (System.Windows.Forms.RadioButton)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rad.Name;
                    if (File.Exists(fileName))
                    {
                        rad.Checked = Convert.ToBoolean(readFile(fileName));
                    }

                }

                if (c is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox rad = (System.Windows.Forms.CheckBox)c;
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Controls/" + "/" + rad.Name;
                    if (File.Exists(fileName))
                    {
                        rad.Checked = Convert.ToBoolean(readFile(fileName));
                    }

                }




            }


        }

    }
}
