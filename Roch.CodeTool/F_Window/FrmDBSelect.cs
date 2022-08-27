using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Roch.DomainModel;
using Roch.Framework;

namespace Roch.CodeTool.F_Window
{
    public partial class FrmDBSelect : BaseForm
    {
        public FrmDBSelect()
        {
            InitializeComponent();

            List<Control> list = new List<Control>();
            list.Add(this.rbSQLServer2008);
            list.Add(this.rbSQL);
            list.Add(this.rbOracle);
            FileOperate.loadAllForms(list);
        }

        public DatabaseType DatabaseType;

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            List<Control> list = new List<Control>();
            list.Add(this.rbSQLServer2008);
            list.Add(this.rbSQL);
            list.Add(this.rbOracle);
            FileOperate.saveAllForms(list);

            if (rbSQL.Checked)
            {
                DatabaseType = DatabaseType.SQLServer;
            }
            else if (rbSQLServer2008.Checked)
            {
                DatabaseType = DatabaseType.SQLServer2008;
            }
            else if (rbOracle.Checked)
            {
                DatabaseType = DatabaseType.Oracle;
            }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消
        /// </summary>        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ShowQuestion("是否要取消?") == DialogResult.Yes)
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
