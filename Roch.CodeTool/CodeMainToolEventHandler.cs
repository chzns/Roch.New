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
using System.Text;
using System.Windows.Forms;

using Roch.CodeTool.F_Window;
using Roch.DomainModel;
using Roch.Database;
using Roch.Framework;

namespace Roch.CodeTool
{
    /// <summary>
    /// 主界面工具栏事件处理
    /// </summary>
    public partial class CodeMain
    {
        /// <summary>
        /// 服务器初始化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbServer_Click(object sender, EventArgs e)
        {
            FrmDBSelect frmDBSelect = new FrmDBSelect();
            if (frmDBSelect.ShowDialog() == DialogResult.OK)
            {
                FrmSetServer frmServer = new FrmSetServer(frmDBSelect.DatabaseType);
                if (frmServer.ShowDialog() == DialogResult.OK)
                {
                    LoadServerTreeNode();
                }
            }
            List<Control> list = new List<Control>();
            //list.Add(this.txtClassName);
            //list.Add(this.txtPK);
            //list.Add(this.txtDescript);
            //list.Add(this.txtColumns);
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

        /// <summary>
        /// 加载数据库
        /// </summary>
        private void LoadServerTreeNode()
        {
            //tvServer.Nodes.Clear();

            TreeNode serverNode = new TreeNode(DatabaseMapper.Instance.ServerName + string.Format("({0})", DatabaseMapper.Instance.DatabaseType.ToString()));

            if (DatabaseMapper.Instance.DatabaseType == DatabaseType.SQLServer)
            {
                foreach (DatabaseModel database in DatabaseMapper.Instance.FindAllDatabases(DatabaseMapper.Instance.DatabaseType))
                {
                    TreeNode databaseNode = new TreeNode(database.Name);
                    TreeNode tableNode = new TreeNode("Table");
                    TreeNode viewNode = new TreeNode("View");
                    TreeNode produceNode = new TreeNode("Procedure");

                    tableNode.Tag = DBObjectType.Table;
                    viewNode.Tag = DBObjectType.View;
                    produceNode.Tag = DBObjectType.Procedure;

                    databaseNode.Nodes.Add(tableNode);
                    databaseNode.Nodes.Add(viewNode);
                    databaseNode.Nodes.Add(produceNode);

                    serverNode.Nodes.Add(databaseNode);
                }
            }
            else if (DatabaseMapper.Instance.DatabaseType == DatabaseType.Oracle)
            {
                TreeNode databaseNode = new TreeNode(DatabaseMapper.Instance.ServerName);

                TreeNode tableNode = new TreeNode("Table");
                TreeNode viewNode = new TreeNode("View");
                TreeNode produceNode = new TreeNode("Procedure");

                tableNode.Tag = DBObjectType.Table;
                viewNode.Tag = DBObjectType.View;
                produceNode.Tag = DBObjectType.Procedure;

                databaseNode.Nodes.Add(tableNode);
                databaseNode.Nodes.Add(viewNode);
                databaseNode.Nodes.Add(produceNode);

                serverNode.Nodes.Add(databaseNode);
            }
            else if (DatabaseMapper.Instance.DatabaseType == DatabaseType.SQLServer2008)
            {
                foreach (DatabaseModel database in DatabaseMapper.Instance.FindAllDatabases(DatabaseMapper.Instance.DatabaseType))
                {
                    TreeNode databaseNode = new TreeNode(database.Name);
                    TreeNode tableNode = new TreeNode("Table");
                    TreeNode viewNode = new TreeNode("View");
                    TreeNode produceNode = new TreeNode("Procedure");

                    tableNode.Tag = DBObjectType.Table;
                    viewNode.Tag = DBObjectType.View;
                    produceNode.Tag = DBObjectType.Procedure;

                    databaseNode.Nodes.Add(tableNode);
                    databaseNode.Nodes.Add(viewNode);
                    databaseNode.Nodes.Add(produceNode);

                    serverNode.Nodes.Add(databaseNode);
                }
            }

            serverNode.Expand();
            //tvServer.Nodes.Add(serverNode);
        }

        /// <summary>
        /// 代码生成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCoding_Click(object sender, EventArgs e)
        {
            //btnGenerated.PerformClick();
            tbControl.SelectedIndex = 0;
        }

        /// <summary>
        /// 导出Excel事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExportExcel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 导出Work事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExportWord_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 导出数据脚本事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExportData_Click(object sender, EventArgs e)
        {
            //btnGenerated.PerformClick();
            tbControl.SelectedIndex = 5;
        }

        /// <summary>
        /// 导出数据库结构事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExportStruct_Click(object sender, EventArgs e)
        {
            //btnGenerated.PerformClick();
            tbControl.SelectedIndex = 6;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbConfig_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打开默认文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbOpenDirPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", m_DirPath);
        }

        private void tsbOpenDebugPath_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("Explorer", m_DebugPath);
        }


        /// <summary>
        /// 模板配置说明文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbTemlateDescript_Click(object sender, EventArgs e)
        {
            new FrmDisplay().ShowDialog();
        }

      
    }
}
