namespace Roch.CodeTool.F_Window
{
    partial class FrmDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbContent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rbContent
            // 
            this.rbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbContent.Location = new System.Drawing.Point(0, 0);
            this.rbContent.Name = "rbContent";
            this.rbContent.ReadOnly = true;
            this.rbContent.Size = new System.Drawing.Size(771, 404);
            this.rbContent.TabIndex = 0;
            this.rbContent.Text = "";
            // 
            // FrmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 404);
            this.Controls.Add(this.rbContent);
            this.Name = "FrmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板内容说明";
            this.Load += new System.EventHandler(this.FrmDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbContent;
    }
}