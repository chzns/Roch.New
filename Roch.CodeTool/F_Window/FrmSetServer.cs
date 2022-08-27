//======================================================================
//
//        Copyright (C) 2011-2012 xxxxxxxx
//        All rights reserved
//
//        filename :FrmSetServer
//        description :
//
//        created by potato at  8/8/2011 4:17:07 PM
//        Email :nq.xxx@gmail.com
//
//======================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Roch.Database;
using Roch.DomainModel;
using Roch.Framework;

namespace Roch.CodeTool.F_Window
{
    /// <summary>
    /// 设置服务器
    /// </summary>
    public partial class FrmSetServer : BaseForm
    {
        private DatabaseType m_DatabaseType;

        public FrmSetServer()
        {
            InitializeComponent();
        }

        public FrmSetServer(DatabaseType databaseType)
            : this()
        {
            m_DatabaseType = databaseType;
            List<Control> list = new List<Control>();
            list.Add(this.txtServer);
            list.Add(this.txtUser);
            list.Add(this.txtPassword);
            FileOperate.loadAllForms(list);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DatabaseMapper.Instance.ServerName = txtServer.Text;
            DatabaseMapper.Instance.UserName = txtUser.Text;
            DatabaseMapper.Instance.Password = txtPassword.Text;
            DatabaseMapper.Instance.DatabaseType = m_DatabaseType;

            string message = DatabaseMapper.Instance.TestConnection() ? "连接成功!" : "连接失败!";
            ShowPrompt(message);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

            List<Control> list = new List<Control>();
            list.Add(this.txtServer);
            list.Add(this.txtUser);
            list.Add(this.txtPassword);

            FileOperate.saveAllForms(list);
            string message = DatabaseMapper.CreateInstance(txtServer.Text, txtUser.Text, txtPassword.Text, m_DatabaseType) ? "初始化成功" : "初始化失败";

            ShowPrompt(message);

            if (DatabaseMapper.Instance.IsConnection)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ShowQuestion("是否要取消?") == DialogResult.Yes)
            {
                DialogResult = DialogResult.Yes;
                Close();
            }
        }
    }
}
