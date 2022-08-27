using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Roch.CodeTool
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public void ShowPrompt(string message)
        {
            MessageBox.Show(message, "提示");
        }

        public DialogResult ShowQuestion(string message)
        {
            return MessageBox.Show(message, "提示", MessageBoxButtons.YesNo);
        }
    }
}
