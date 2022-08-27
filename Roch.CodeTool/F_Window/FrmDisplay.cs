//======================================================================
//
// Copyright (C) 2013-2015 xxxxxxxx
// All rights reserved
//
// filename :FrmDisplay
// description :
//
// created by potato at 11/20/2014 9:43:43 PM
// Email :nq.xxx@gmail.com
//
//======================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Roch.CodeTool.F_Window
{
    public partial class FrmDisplay : BaseForm
    {
        public FrmDisplay()
        {
            InitializeComponent();
        }

        private void FrmDisplay_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, "模板说明.txt"), Encoding.UTF8);
            string content = sr.ReadToEnd();
            sr.Close();

            rbContent.Text = content;
        }
    }
}
