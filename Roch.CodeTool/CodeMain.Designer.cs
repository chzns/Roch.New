namespace Roch.CodeTool
{
    partial class CodeMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeMain));
            this.contexMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_sbname = new System.Windows.Forms.TextBox();
            this.btn_sb_copy = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_sb_2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btn_generate_name = new System.Windows.Forms.Button();
            this.btn_sb_n = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btn_sb_single = new System.Windows.Forms.Button();
            this.btn_htm_generate = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_sb_generate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.html = new System.Windows.Forms.TabPage();
            this.rich_sb_new = new System.Windows.Forms.RichTextBox();
            this.rich_sb_old = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtPK = new System.Windows.Forms.TextBox();
            this.btnGenerated = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescript = new System.Windows.Forms.TextBox();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.tsbConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contexMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.html.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // contexMenu
            // 
            this.contexMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contexMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsSelect,
            this.tsCopy});
            this.contexMenu.Name = "contexMenu";
            this.contexMenu.Size = new System.Drawing.Size(105, 70);
            // 
            // tsmSave
            // 
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(104, 22);
            this.tsmSave.Text = "保 存";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsSelect
            // 
            this.tsSelect.Name = "tsSelect";
            this.tsSelect.Size = new System.Drawing.Size(104, 22);
            this.tsSelect.Text = "全 选";
            this.tsSelect.Click += new System.EventHandler(this.tsSelect_Click);
            // 
            // tsCopy
            // 
            this.tsCopy.Name = "tsCopy";
            this.tsCopy.Size = new System.Drawing.Size(104, 22);
            this.tsCopy.Text = "复 制";
            this.tsCopy.Click += new System.EventHandler(this.tsCopy_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(1245, 796);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_sbname);
            this.groupBox1.Controls.Add(this.btn_sb_copy);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btn_sb_2);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.btn_generate_name);
            this.groupBox1.Controls.Add(this.btn_sb_n);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.btn_sb_single);
            this.groupBox1.Controls.Add(this.btn_htm_generate);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.btn_sb_generate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 786);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Function";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(18, 350);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(130, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "String->C#(Formate)";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Result->Common(C#)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_sbname
            // 
            this.txt_sbname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sbname.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_sbname.Location = new System.Drawing.Point(18, 25);
            this.txt_sbname.Name = "txt_sbname";
            this.txt_sbname.Size = new System.Drawing.Size(130, 21);
            this.txt_sbname.TabIndex = 3;
            this.txt_sbname.Text = "sb";
            // 
            // btn_sb_copy
            // 
            this.btn_sb_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sb_copy.Location = new System.Drawing.Point(18, 621);
            this.btn_sb_copy.Name = "btn_sb_copy";
            this.btn_sb_copy.Size = new System.Drawing.Size(130, 21);
            this.btn_sb_copy.TabIndex = 5;
            this.btn_sb_copy.Text = "Copy";
            this.btn_sb_copy.UseVisualStyleBackColor = true;
            this.btn_sb_copy.Click += new System.EventHandler(this.btn_sb_copy_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 21);
            this.button3.TabIndex = 12;
            this.button3.Text = "VS Code Template";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_sb_2
            // 
            this.btn_sb_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sb_2.Location = new System.Drawing.Point(18, 169);
            this.btn_sb_2.Name = "btn_sb_2";
            this.btn_sb_2.Size = new System.Drawing.Size(130, 21);
            this.btn_sb_2.TabIndex = 9;
            this.btn_sb_2.Text = "(c#)new";
            this.btn_sb_2.UseVisualStyleBackColor = true;
            this.btn_sb_2.Click += new System.EventHandler(this.btn_sb_2_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(18, 421);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(130, 21);
            this.button9.TabIndex = 18;
            this.button9.Text = "Resault->List";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // btn_generate_name
            // 
            this.btn_generate_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generate_name.Location = new System.Drawing.Point(18, 250);
            this.btn_generate_name.Name = "btn_generate_name";
            this.btn_generate_name.Size = new System.Drawing.Size(130, 21);
            this.btn_generate_name.TabIndex = 10;
            this.btn_generate_name.Text = "Generate(Name)";
            this.btn_generate_name.UseVisualStyleBackColor = true;
            this.btn_generate_name.Click += new System.EventHandler(this.btn_generate_name_Click);
            // 
            // btn_sb_n
            // 
            this.btn_sb_n.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sb_n.Location = new System.Drawing.Point(18, 133);
            this.btn_sb_n.Name = "btn_sb_n";
            this.btn_sb_n.Size = new System.Drawing.Size(130, 21);
            this.btn_sb_n.TabIndex = 8;
            this.btn_sb_n.Text = "(c#)List";
            this.btn_sb_n.UseVisualStyleBackColor = true;
            this.btn_sb_n.Click += new System.EventHandler(this.btn_sb_n_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(18, 457);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 21);
            this.button6.TabIndex = 15;
            this.button6.Text = "Resault->Json";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 21);
            this.button2.TabIndex = 11;
            this.button2.Text = "String->AppendLine";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_sb_generate_Click1);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(18, 493);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(130, 21);
            this.button8.TabIndex = 17;
            this.button8.Text = "Resault->Table||Data";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // btn_sb_single
            // 
            this.btn_sb_single.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sb_single.Location = new System.Drawing.Point(18, 61);
            this.btn_sb_single.Name = "btn_sb_single";
            this.btn_sb_single.Size = new System.Drawing.Size(130, 21);
            this.btn_sb_single.TabIndex = 7;
            this.btn_sb_single.Text = "(html)Single";
            this.btn_sb_single.UseVisualStyleBackColor = true;
            this.btn_sb_single.Click += new System.EventHandler(this.btn_sb_single_Click);
            // 
            // btn_htm_generate
            // 
            this.btn_htm_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_htm_generate.Location = new System.Drawing.Point(18, 97);
            this.btn_htm_generate.Name = "btn_htm_generate";
            this.btn_htm_generate.Size = new System.Drawing.Size(130, 21);
            this.btn_htm_generate.TabIndex = 6;
            this.btn_htm_generate.Text = "html";
            this.btn_htm_generate.UseVisualStyleBackColor = true;
            this.btn_htm_generate.Click += new System.EventHandler(this.btn_htm_generate_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(18, 565);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(130, 21);
            this.button7.TabIndex = 16;
            this.button7.Text = "WTMFormItem->Enitity";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 21);
            this.button4.TabIndex = 13;
            this.button4.Text = "String->LinqPad";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.Enter += new System.EventHandler(this.button4_Enter);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(18, 529);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 21);
            this.button5.TabIndex = 14;
            this.button5.Text = "Resault->Table";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_sb_generate
            // 
            this.btn_sb_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sb_generate.Location = new System.Drawing.Point(18, 205);
            this.btn_sb_generate.Name = "btn_sb_generate";
            this.btn_sb_generate.Size = new System.Drawing.Size(130, 21);
            this.btn_sb_generate.TabIndex = 5;
            this.btn_sb_generate.Text = "(c#)";
            this.btn_sb_generate.UseVisualStyleBackColor = true;
            this.btn_sb_generate.Click += new System.EventHandler(this.btn_sb_generate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 90);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(973, 701);
            this.panel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbControl);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(973, 696);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generate Code";
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.html);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(5, 19);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(963, 672);
            this.tbControl.TabIndex = 0;
            // 
            // html
            // 
            this.html.Controls.Add(this.rich_sb_new);
            this.html.Controls.Add(this.rich_sb_old);
            this.html.Location = new System.Drawing.Point(4, 22);
            this.html.Name = "html";
            this.html.Size = new System.Drawing.Size(955, 646);
            this.html.TabIndex = 9;
            this.html.Text = "Common Code";
            this.html.UseVisualStyleBackColor = true;
            // 
            // rich_sb_new
            // 
            this.rich_sb_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rich_sb_new.Location = new System.Drawing.Point(0, 185);
            this.rich_sb_new.Name = "rich_sb_new";
            this.rich_sb_new.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rich_sb_new.Size = new System.Drawing.Size(955, 461);
            this.rich_sb_new.TabIndex = 12;
            this.rich_sb_new.Text = "";
            // 
            // rich_sb_old
            // 
            this.rich_sb_old.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rich_sb_old.Dock = System.Windows.Forms.DockStyle.Top;
            this.rich_sb_old.Location = new System.Drawing.Point(0, 0);
            this.rich_sb_old.Name = "rich_sb_old";
            this.rich_sb_old.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rich_sb_old.Size = new System.Drawing.Size(955, 185);
            this.rich_sb_old.TabIndex = 11;
            this.rich_sb_old.Text = "";
            this.rich_sb_old.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(973, 85);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ClassItem";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtClassName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPK, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerated, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescript, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtColumns, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ClassName";
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.Location = new System.Drawing.Point(63, 4);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(267, 21);
            this.txtClassName.TabIndex = 0;
            // 
            // txtPK
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPK, 2);
            this.txtPK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPK.Location = new System.Drawing.Point(406, 3);
            this.txtPK.Name = "txtPK";
            this.txtPK.Size = new System.Drawing.Size(347, 21);
            this.txtPK.TabIndex = 1;
            // 
            // btnGenerated
            // 
            this.btnGenerated.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnGenerated.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGenerated.Location = new System.Drawing.Point(759, 33);
            this.btnGenerated.Name = "btnGenerated";
            this.btnGenerated.Size = new System.Drawing.Size(75, 23);
            this.btnGenerated.TabIndex = 3;
            this.btnGenerated.Text = "Generate";
            this.btnGenerated.UseVisualStyleBackColor = true;
            this.btnGenerated.Click += new System.EventHandler(this.btnGenerated_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Desc";
            // 
            // txtDescript
            // 
            this.txtDescript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescript.Location = new System.Drawing.Point(63, 34);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.Size = new System.Drawing.Size(267, 21);
            this.txtDescript.TabIndex = 2;
            // 
            // txtColumns
            // 
            this.txtColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColumns.Location = new System.Drawing.Point(486, 32);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(267, 21);
            this.txtColumns.TabIndex = 4;
            // 
            // tsTool
            // 
            this.tsTool.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConfig,
            this.toolStripButton2,
            this.toolStripButton3});
            this.tsTool.Location = new System.Drawing.Point(0, 0);
            this.tsTool.Name = "tsTool";
            this.tsTool.Size = new System.Drawing.Size(1245, 44);
            this.tsTool.TabIndex = 0;
            this.tsTool.Text = "tsTool";
            // 
            // tsbConfig
            // 
            this.tsbConfig.Image = global::Roch.CodeTool.Properties.Resources.wrench__pencil;
            this.tsbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfig.Name = "tsbConfig";
            this.tsbConfig.Size = new System.Drawing.Size(53, 41);
            this.tsbConfig.Text = "System";
            this.tsbConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbConfig.Click += new System.EventHandler(this.tsbConfig_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Roch.CodeTool.Properties.Resources.folder_horizontal_open;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(83, 41);
            this.toolStripButton2.Text = "OpenDebug";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.tsbOpenDebugPath_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Roch.CodeTool.Properties.Resources.paper_bag_label;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(39, 41);
            this.toolStripButton3.Text = "Save";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // CodeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 840);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsTool);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CodeMain";
            this.Text = "Google Chrome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeMain_FormClosing);
            this.Load += new System.EventHandler(this.CodeMain_Load);
            this.contexMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tbControl.ResumeLayout(false);
            this.html.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTool;
        private System.Windows.Forms.ToolStripButton tsbConfig;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtPK;
        private System.Windows.Forms.Button btnGenerated;
        private System.Windows.Forms.ContextMenuStrip contexMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescript;
        private System.Windows.Forms.ToolStripMenuItem tsSelect;
        private System.Windows.Forms.ToolStripMenuItem tsCopy;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TabPage html;
        private System.Windows.Forms.TextBox txt_sbname;
        private System.Windows.Forms.Button btn_sb_copy;
        private System.Windows.Forms.Button btn_sb_generate;
        private System.Windows.Forms.Button btn_htm_generate;
        private System.Windows.Forms.Button btn_sb_single;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox rich_sb_new;
        private System.Windows.Forms.RichTextBox rich_sb_old;
        private System.Windows.Forms.Button btn_sb_n;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Button btn_sb_2;
        private System.Windows.Forms.Button btn_generate_name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button10;
    }
}

