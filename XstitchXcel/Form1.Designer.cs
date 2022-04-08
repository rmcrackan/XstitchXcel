
namespace XstitchXcel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.fileNameTb = new System.Windows.Forms.TextBox();
            this.fileNameBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.createPatternTabPage = new System.Windows.Forms.TabPage();
            this.createPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.CreatePatternSplitPanel();
            this.findDmcColorsTabPage = new System.Windows.Forms.TabPage();
            this.findDmcColorsBtn = new System.Windows.Forms.Button();
            this.findDmcColorsInstructionsTb = new System.Windows.Forms.TextBox();
            this.replaceColorTabPage = new System.Windows.Forms.TabPage();
            this.newIsDmcLbl = new System.Windows.Forms.Label();
            this.oldIsDmcLbl = new System.Windows.Forms.Label();
            this.replaceColorInstructionsTb = new System.Windows.Forms.TextBox();
            this.beginColorReplaceBtn = new System.Windows.Forms.Button();
            this.newColorPb = new System.Windows.Forms.PictureBox();
            this.newColorTb = new System.Windows.Forms.TextBox();
            this.newColorLbl = new System.Windows.Forms.Label();
            this.oldColorPb = new System.Windows.Forms.PictureBox();
            this.oldColorTb = new System.Windows.Forms.TextBox();
            this.oldColorLbl = new System.Windows.Forms.Label();
            this.replaceColorBakCb = new System.Windows.Forms.CheckBox();
            this.replaceColorNaiveTabPage = new System.Windows.Forms.TabPage();
            this.newIsDmcNaiveLbl = new System.Windows.Forms.Label();
            this.oldIsDmcNaiveLbl = new System.Windows.Forms.Label();
            this.replaceColorNaiveInstructionsTb = new System.Windows.Forms.TextBox();
            this.beginColorReplaceNaiveBtn = new System.Windows.Forms.Button();
            this.newColorNaivePb = new System.Windows.Forms.PictureBox();
            this.newColorNaiveTb = new System.Windows.Forms.TextBox();
            this.newColorNaiveLbl = new System.Windows.Forms.Label();
            this.oldColorNaivePb = new System.Windows.Forms.PictureBox();
            this.oldColorNaiveTb = new System.Windows.Forms.TextBox();
            this.oldColorNaiveLbl = new System.Windows.Forms.Label();
            this.replaceColorNaiveBakCb = new System.Windows.Forms.CheckBox();
            this.batchConvertTabPage = new System.Windows.Forms.TabPage();
            this.batchConvertStart = new System.Windows.Forms.Button();
            this.batchConvertDestinationBtn = new System.Windows.Forms.Button();
            this.batchConvertDestinationTb = new System.Windows.Forms.TextBox();
            this.batchConvertDestinationLbl = new System.Windows.Forms.Label();
            this.batchConvertSourceBtn = new System.Windows.Forms.Button();
            this.batchConvertSourceTb = new System.Windows.Forms.TextBox();
            this.batchConvertSourceLbl = new System.Windows.Forms.Label();
            this.batchConvertInstructionsTb = new System.Windows.Forms.TextBox();
            this.toPngTabPage = new System.Windows.Forms.TabPage();
            this.toPngNud = new System.Windows.Forms.NumericUpDown();
            this.toPngScaleRb = new System.Windows.Forms.RadioButton();
            this.toPngOriginalRb = new System.Windows.Forms.RadioButton();
            this.toPngInstructionsTb = new System.Windows.Forms.TextBox();
            this.createPngBtn = new System.Windows.Forms.Button();
            this.toPngOutputBtn = new System.Windows.Forms.Button();
            this.toPngOutputTb = new System.Windows.Forms.TextBox();
            this.toPngOutputLbl = new System.Windows.Forms.Label();
            this.crtBlurTabPage = new System.Windows.Forms.TabPage();
            this.crtBlurInstructionsTb = new System.Windows.Forms.TextBox();
            this.createCrtBlurBtn = new System.Windows.Forms.Button();
            this.crtBlurOutputBtn = new System.Windows.Forms.Button();
            this.crtBlurOutputTb = new System.Windows.Forms.TextBox();
            this.crtBlurOutputLbl = new System.Windows.Forms.Label();
            this.statsTabPage = new System.Windows.Forms.TabPage();
            this.statsPanel1 = new XstitchXcelWinFormsLib.Panels.StatsPanel();
            this.tabControl.SuspendLayout();
            this.createPatternTabPage.SuspendLayout();
            this.findDmcColorsTabPage.SuspendLayout();
            this.replaceColorTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newColorPb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldColorPb)).BeginInit();
            this.replaceColorNaiveTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newColorNaivePb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldColorNaivePb)).BeginInit();
            this.batchConvertTabPage.SuspendLayout();
            this.toPngTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).BeginInit();
            this.crtBlurTabPage.SuspendLayout();
            this.statsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(12, 16);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(56, 15);
            this.fileNameLbl.TabIndex = 0;
            this.fileNameLbl.Text = "Excel file:";
            // 
            // fileNameTb
            // 
            this.fileNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTb.Location = new System.Drawing.Point(74, 13);
            this.fileNameTb.Name = "fileNameTb";
            this.fileNameTb.Size = new System.Drawing.Size(662, 23);
            this.fileNameTb.TabIndex = 1;
            this.fileNameTb.TextChanged += new System.EventHandler(this.fileNameTb_TextChanged);
            // 
            // fileNameBtn
            // 
            this.fileNameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameBtn.Location = new System.Drawing.Point(742, 12);
            this.fileNameBtn.Name = "fileNameBtn";
            this.fileNameBtn.Size = new System.Drawing.Size(32, 23);
            this.fileNameBtn.TabIndex = 2;
            this.fileNameBtn.Text = "...";
            this.fileNameBtn.UseVisualStyleBackColor = true;
            this.fileNameBtn.Click += new System.EventHandler(this.fileNameBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.createPatternTabPage);
            this.tabControl.Controls.Add(this.statsTabPage);
            this.tabControl.Controls.Add(this.findDmcColorsTabPage);
            this.tabControl.Controls.Add(this.replaceColorTabPage);
            this.tabControl.Controls.Add(this.replaceColorNaiveTabPage);
            this.tabControl.Controls.Add(this.batchConvertTabPage);
            this.tabControl.Controls.Add(this.toPngTabPage);
            this.tabControl.Controls.Add(this.crtBlurTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(762, 381);
            this.tabControl.TabIndex = 3;
            // 
            // createPatternTabPage
            // 
            this.createPatternTabPage.Controls.Add(this.createPatternSplitPanel1);
            this.createPatternTabPage.Location = new System.Drawing.Point(4, 24);
            this.createPatternTabPage.Name = "createPatternTabPage";
            this.createPatternTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.createPatternTabPage.Size = new System.Drawing.Size(754, 353);
            this.createPatternTabPage.TabIndex = 8;
            this.createPatternTabPage.Text = "Create Pattern";
            this.createPatternTabPage.UseVisualStyleBackColor = true;
            // 
            // createPatternSplitPanel1
            // 
            this.createPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createPatternSplitPanel1.Location = new System.Drawing.Point(3, 3);
            this.createPatternSplitPanel1.Name = "createPatternSplitPanel1";
            this.createPatternSplitPanel1.Size = new System.Drawing.Size(748, 347);
            this.createPatternSplitPanel1.TabIndex = 0;
            // 
            // findDmcColorsTabPage
            // 
            this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsBtn);
            this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsInstructionsTb);
            this.findDmcColorsTabPage.Location = new System.Drawing.Point(4, 24);
            this.findDmcColorsTabPage.Name = "findDmcColorsTabPage";
            this.findDmcColorsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.findDmcColorsTabPage.Size = new System.Drawing.Size(754, 353);
            this.findDmcColorsTabPage.TabIndex = 2;
            this.findDmcColorsTabPage.Text = "Find DMC Colors";
            this.findDmcColorsTabPage.UseVisualStyleBackColor = true;
            // 
            // findDmcColorsBtn
            // 
            this.findDmcColorsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findDmcColorsBtn.Location = new System.Drawing.Point(591, 318);
            this.findDmcColorsBtn.Name = "findDmcColorsBtn";
            this.findDmcColorsBtn.Size = new System.Drawing.Size(160, 23);
            this.findDmcColorsBtn.TabIndex = 11;
            this.findDmcColorsBtn.Text = "Create Reports";
            this.findDmcColorsBtn.UseVisualStyleBackColor = true;
            this.findDmcColorsBtn.Click += new System.EventHandler(this.findDmcColorsBtn_Click);
            // 
            // findDmcColorsInstructionsTb
            // 
            this.findDmcColorsInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findDmcColorsInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.findDmcColorsInstructionsTb.Multiline = true;
            this.findDmcColorsInstructionsTb.Name = "findDmcColorsInstructionsTb";
            this.findDmcColorsInstructionsTb.ReadOnly = true;
            this.findDmcColorsInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.findDmcColorsInstructionsTb.Size = new System.Drawing.Size(748, 206);
            this.findDmcColorsInstructionsTb.TabIndex = 10;
            this.findDmcColorsInstructionsTb.Text = "Finds the non-DMC colors in your file. Creates report with the closest DMC matche" +
    "s";
            // 
            // replaceColorTabPage
            // 
            this.replaceColorTabPage.Controls.Add(this.newIsDmcLbl);
            this.replaceColorTabPage.Controls.Add(this.oldIsDmcLbl);
            this.replaceColorTabPage.Controls.Add(this.replaceColorInstructionsTb);
            this.replaceColorTabPage.Controls.Add(this.beginColorReplaceBtn);
            this.replaceColorTabPage.Controls.Add(this.newColorPb);
            this.replaceColorTabPage.Controls.Add(this.newColorTb);
            this.replaceColorTabPage.Controls.Add(this.newColorLbl);
            this.replaceColorTabPage.Controls.Add(this.oldColorPb);
            this.replaceColorTabPage.Controls.Add(this.oldColorTb);
            this.replaceColorTabPage.Controls.Add(this.oldColorLbl);
            this.replaceColorTabPage.Controls.Add(this.replaceColorBakCb);
            this.replaceColorTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorTabPage.Name = "replaceColorTabPage";
            this.replaceColorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.replaceColorTabPage.Size = new System.Drawing.Size(754, 353);
            this.replaceColorTabPage.TabIndex = 3;
            this.replaceColorTabPage.Text = "Replace Color";
            this.replaceColorTabPage.UseVisualStyleBackColor = true;
            // 
            // newIsDmcLbl
            // 
            this.newIsDmcLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newIsDmcLbl.AutoSize = true;
            this.newIsDmcLbl.Location = new System.Drawing.Point(331, 284);
            this.newIsDmcLbl.Name = "newIsDmcLbl";
            this.newIsDmcLbl.Size = new System.Drawing.Size(38, 15);
            this.newIsDmcLbl.TabIndex = 6;
            this.newIsDmcLbl.Text = "label2";
            this.newIsDmcLbl.Visible = false;
            // 
            // oldIsDmcLbl
            // 
            this.oldIsDmcLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldIsDmcLbl.AutoSize = true;
            this.oldIsDmcLbl.Location = new System.Drawing.Point(331, 255);
            this.oldIsDmcLbl.Name = "oldIsDmcLbl";
            this.oldIsDmcLbl.Size = new System.Drawing.Size(38, 15);
            this.oldIsDmcLbl.TabIndex = 3;
            this.oldIsDmcLbl.Text = "label1";
            this.oldIsDmcLbl.Visible = false;
            // 
            // replaceColorInstructionsTb
            // 
            this.replaceColorInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceColorInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.replaceColorInstructionsTb.Multiline = true;
            this.replaceColorInstructionsTb.Name = "replaceColorInstructionsTb";
            this.replaceColorInstructionsTb.ReadOnly = true;
            this.replaceColorInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.replaceColorInstructionsTb.Size = new System.Drawing.Size(748, 218);
            this.replaceColorInstructionsTb.TabIndex = 1;
            this.replaceColorInstructionsTb.Text = resources.GetString("replaceColorInstructionsTb.Text");
            // 
            // beginColorReplaceBtn
            // 
            this.beginColorReplaceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.beginColorReplaceBtn.Location = new System.Drawing.Point(591, 318);
            this.beginColorReplaceBtn.Name = "beginColorReplaceBtn";
            this.beginColorReplaceBtn.Size = new System.Drawing.Size(160, 23);
            this.beginColorReplaceBtn.TabIndex = 4;
            this.beginColorReplaceBtn.Text = "Begin color replace";
            this.beginColorReplaceBtn.UseVisualStyleBackColor = true;
            this.beginColorReplaceBtn.Click += new System.EventHandler(this.beginColorReplaceBtn_Click);
            // 
            // newColorPb
            // 
            this.newColorPb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newColorPb.Location = new System.Drawing.Point(207, 281);
            this.newColorPb.Name = "newColorPb";
            this.newColorPb.Size = new System.Drawing.Size(100, 23);
            this.newColorPb.TabIndex = 6;
            this.newColorPb.TabStop = false;
            this.newColorPb.Visible = false;
            // 
            // newColorTb
            // 
            this.newColorTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorTb.Location = new System.Drawing.Point(81, 281);
            this.newColorTb.Name = "newColorTb";
            this.newColorTb.Size = new System.Drawing.Size(100, 23);
            this.newColorTb.TabIndex = 3;
            this.newColorTb.TextChanged += new System.EventHandler(this.newColorTb_TextChanged);
            this.newColorTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newColorTb_KeyPress);
            // 
            // newColorLbl
            // 
            this.newColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorLbl.AutoSize = true;
            this.newColorLbl.Location = new System.Drawing.Point(3, 284);
            this.newColorLbl.Name = "newColorLbl";
            this.newColorLbl.Size = new System.Drawing.Size(64, 15);
            this.newColorLbl.TabIndex = 4;
            this.newColorLbl.Text = "New color:";
            // 
            // oldColorPb
            // 
            this.oldColorPb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldColorPb.Location = new System.Drawing.Point(207, 252);
            this.oldColorPb.Name = "oldColorPb";
            this.oldColorPb.Size = new System.Drawing.Size(100, 23);
            this.oldColorPb.TabIndex = 3;
            this.oldColorPb.TabStop = false;
            this.oldColorPb.Visible = false;
            // 
            // oldColorTb
            // 
            this.oldColorTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorTb.Location = new System.Drawing.Point(81, 252);
            this.oldColorTb.Name = "oldColorTb";
            this.oldColorTb.Size = new System.Drawing.Size(100, 23);
            this.oldColorTb.TabIndex = 1;
            this.oldColorTb.TextChanged += new System.EventHandler(this.oldColorTb_TextChanged);
            this.oldColorTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oldColorTb_KeyPress);
            // 
            // oldColorLbl
            // 
            this.oldColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorLbl.AutoSize = true;
            this.oldColorLbl.Location = new System.Drawing.Point(3, 255);
            this.oldColorLbl.Name = "oldColorLbl";
            this.oldColorLbl.Size = new System.Drawing.Size(59, 15);
            this.oldColorLbl.TabIndex = 3;
            this.oldColorLbl.Text = "Old color:";
            // 
            // replaceColorBakCb
            // 
            this.replaceColorBakCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceColorBakCb.AutoSize = true;
            this.replaceColorBakCb.Location = new System.Drawing.Point(3, 227);
            this.replaceColorBakCb.Name = "replaceColorBakCb";
            this.replaceColorBakCb.Size = new System.Drawing.Size(234, 19);
            this.replaceColorBakCb.TabIndex = 0;
            this.replaceColorBakCb.Text = "Back up my file before making changes";
            this.replaceColorBakCb.UseVisualStyleBackColor = true;
            // 
            // replaceColorNaiveTabPage
            // 
            this.replaceColorNaiveTabPage.Controls.Add(this.newIsDmcNaiveLbl);
            this.replaceColorNaiveTabPage.Controls.Add(this.oldIsDmcNaiveLbl);
            this.replaceColorNaiveTabPage.Controls.Add(this.replaceColorNaiveInstructionsTb);
            this.replaceColorNaiveTabPage.Controls.Add(this.beginColorReplaceNaiveBtn);
            this.replaceColorNaiveTabPage.Controls.Add(this.newColorNaivePb);
            this.replaceColorNaiveTabPage.Controls.Add(this.newColorNaiveTb);
            this.replaceColorNaiveTabPage.Controls.Add(this.newColorNaiveLbl);
            this.replaceColorNaiveTabPage.Controls.Add(this.oldColorNaivePb);
            this.replaceColorNaiveTabPage.Controls.Add(this.oldColorNaiveTb);
            this.replaceColorNaiveTabPage.Controls.Add(this.oldColorNaiveLbl);
            this.replaceColorNaiveTabPage.Controls.Add(this.replaceColorNaiveBakCb);
            this.replaceColorNaiveTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorNaiveTabPage.Name = "replaceColorNaiveTabPage";
            this.replaceColorNaiveTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.replaceColorNaiveTabPage.Size = new System.Drawing.Size(754, 353);
            this.replaceColorNaiveTabPage.TabIndex = 5;
            this.replaceColorNaiveTabPage.Text = "Replace Color (naive)";
            this.replaceColorNaiveTabPage.UseVisualStyleBackColor = true;
            // 
            // newIsDmcNaiveLbl
            // 
            this.newIsDmcNaiveLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newIsDmcNaiveLbl.AutoSize = true;
            this.newIsDmcNaiveLbl.Location = new System.Drawing.Point(331, 284);
            this.newIsDmcNaiveLbl.Name = "newIsDmcNaiveLbl";
            this.newIsDmcNaiveLbl.Size = new System.Drawing.Size(38, 15);
            this.newIsDmcNaiveLbl.TabIndex = 16;
            this.newIsDmcNaiveLbl.Text = "label2";
            this.newIsDmcNaiveLbl.Visible = false;
            // 
            // oldIsDmcNaiveLbl
            // 
            this.oldIsDmcNaiveLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldIsDmcNaiveLbl.AutoSize = true;
            this.oldIsDmcNaiveLbl.Location = new System.Drawing.Point(331, 255);
            this.oldIsDmcNaiveLbl.Name = "oldIsDmcNaiveLbl";
            this.oldIsDmcNaiveLbl.Size = new System.Drawing.Size(38, 15);
            this.oldIsDmcNaiveLbl.TabIndex = 11;
            this.oldIsDmcNaiveLbl.Text = "label1";
            this.oldIsDmcNaiveLbl.Visible = false;
            // 
            // replaceColorNaiveInstructionsTb
            // 
            this.replaceColorNaiveInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceColorNaiveInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.replaceColorNaiveInstructionsTb.Multiline = true;
            this.replaceColorNaiveInstructionsTb.Name = "replaceColorNaiveInstructionsTb";
            this.replaceColorNaiveInstructionsTb.ReadOnly = true;
            this.replaceColorNaiveInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.replaceColorNaiveInstructionsTb.Size = new System.Drawing.Size(748, 218);
            this.replaceColorNaiveInstructionsTb.TabIndex = 8;
            this.replaceColorNaiveInstructionsTb.Text = resources.GetString("replaceColorNaiveInstructionsTb.Text");
            // 
            // beginColorReplaceNaiveBtn
            // 
            this.beginColorReplaceNaiveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.beginColorReplaceNaiveBtn.Location = new System.Drawing.Point(591, 318);
            this.beginColorReplaceNaiveBtn.Name = "beginColorReplaceNaiveBtn";
            this.beginColorReplaceNaiveBtn.Size = new System.Drawing.Size(160, 23);
            this.beginColorReplaceNaiveBtn.TabIndex = 18;
            this.beginColorReplaceNaiveBtn.Text = "Begin color replace";
            this.beginColorReplaceNaiveBtn.UseVisualStyleBackColor = true;
            this.beginColorReplaceNaiveBtn.Click += new System.EventHandler(this.beginColorReplaceNaiveBtn_Click);
            // 
            // newColorNaivePb
            // 
            this.newColorNaivePb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorNaivePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newColorNaivePb.Location = new System.Drawing.Point(207, 281);
            this.newColorNaivePb.Name = "newColorNaivePb";
            this.newColorNaivePb.Size = new System.Drawing.Size(100, 23);
            this.newColorNaivePb.TabIndex = 17;
            this.newColorNaivePb.TabStop = false;
            this.newColorNaivePb.Visible = false;
            // 
            // newColorNaiveTb
            // 
            this.newColorNaiveTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorNaiveTb.Location = new System.Drawing.Point(81, 281);
            this.newColorNaiveTb.Name = "newColorNaiveTb";
            this.newColorNaiveTb.Size = new System.Drawing.Size(100, 23);
            this.newColorNaiveTb.TabIndex = 15;
            this.newColorNaiveTb.TextChanged += new System.EventHandler(this.newColorNaiveTb_TextChanged);
            this.newColorNaiveTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newColorNaiveTb_KeyPress);
            // 
            // newColorNaiveLbl
            // 
            this.newColorNaiveLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newColorNaiveLbl.AutoSize = true;
            this.newColorNaiveLbl.Location = new System.Drawing.Point(3, 284);
            this.newColorNaiveLbl.Name = "newColorNaiveLbl";
            this.newColorNaiveLbl.Size = new System.Drawing.Size(64, 15);
            this.newColorNaiveLbl.TabIndex = 14;
            this.newColorNaiveLbl.Text = "New color:";
            // 
            // oldColorNaivePb
            // 
            this.oldColorNaivePb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorNaivePb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldColorNaivePb.Location = new System.Drawing.Point(207, 252);
            this.oldColorNaivePb.Name = "oldColorNaivePb";
            this.oldColorNaivePb.Size = new System.Drawing.Size(100, 23);
            this.oldColorNaivePb.TabIndex = 12;
            this.oldColorNaivePb.TabStop = false;
            this.oldColorNaivePb.Visible = false;
            // 
            // oldColorNaiveTb
            // 
            this.oldColorNaiveTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorNaiveTb.Location = new System.Drawing.Point(81, 252);
            this.oldColorNaiveTb.Name = "oldColorNaiveTb";
            this.oldColorNaiveTb.Size = new System.Drawing.Size(100, 23);
            this.oldColorNaiveTb.TabIndex = 9;
            this.oldColorNaiveTb.TextChanged += new System.EventHandler(this.oldColorNaiveTb_TextChanged);
            this.oldColorNaiveTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.oldColorNaiveTb_KeyPress);
            // 
            // oldColorNaiveLbl
            // 
            this.oldColorNaiveLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.oldColorNaiveLbl.AutoSize = true;
            this.oldColorNaiveLbl.Location = new System.Drawing.Point(3, 255);
            this.oldColorNaiveLbl.Name = "oldColorNaiveLbl";
            this.oldColorNaiveLbl.Size = new System.Drawing.Size(59, 15);
            this.oldColorNaiveLbl.TabIndex = 13;
            this.oldColorNaiveLbl.Text = "Old color:";
            // 
            // replaceColorNaiveBakCb
            // 
            this.replaceColorNaiveBakCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceColorNaiveBakCb.AutoSize = true;
            this.replaceColorNaiveBakCb.Location = new System.Drawing.Point(3, 227);
            this.replaceColorNaiveBakCb.Name = "replaceColorNaiveBakCb";
            this.replaceColorNaiveBakCb.Size = new System.Drawing.Size(234, 19);
            this.replaceColorNaiveBakCb.TabIndex = 10;
            this.replaceColorNaiveBakCb.Text = "Back up my file before making changes";
            this.replaceColorNaiveBakCb.UseVisualStyleBackColor = true;
            // 
            // batchConvertTabPage
            // 
            this.batchConvertTabPage.Controls.Add(this.batchConvertStart);
            this.batchConvertTabPage.Controls.Add(this.batchConvertDestinationBtn);
            this.batchConvertTabPage.Controls.Add(this.batchConvertDestinationTb);
            this.batchConvertTabPage.Controls.Add(this.batchConvertDestinationLbl);
            this.batchConvertTabPage.Controls.Add(this.batchConvertSourceBtn);
            this.batchConvertTabPage.Controls.Add(this.batchConvertSourceTb);
            this.batchConvertTabPage.Controls.Add(this.batchConvertSourceLbl);
            this.batchConvertTabPage.Controls.Add(this.batchConvertInstructionsTb);
            this.batchConvertTabPage.Location = new System.Drawing.Point(4, 24);
            this.batchConvertTabPage.Name = "batchConvertTabPage";
            this.batchConvertTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.batchConvertTabPage.Size = new System.Drawing.Size(754, 353);
            this.batchConvertTabPage.TabIndex = 6;
            this.batchConvertTabPage.Text = "Batch Convert";
            this.batchConvertTabPage.UseVisualStyleBackColor = true;
            // 
            // batchConvertStart
            // 
            this.batchConvertStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertStart.Location = new System.Drawing.Point(591, 317);
            this.batchConvertStart.Name = "batchConvertStart";
            this.batchConvertStart.Size = new System.Drawing.Size(160, 23);
            this.batchConvertStart.TabIndex = 8;
            this.batchConvertStart.Text = "Start Batch Convert";
            this.batchConvertStart.UseVisualStyleBackColor = true;
            this.batchConvertStart.Click += new System.EventHandler(this.batchConvertStart_Click);
            // 
            // batchConvertDestinationBtn
            // 
            this.batchConvertDestinationBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertDestinationBtn.Location = new System.Drawing.Point(719, 244);
            this.batchConvertDestinationBtn.Name = "batchConvertDestinationBtn";
            this.batchConvertDestinationBtn.Size = new System.Drawing.Size(32, 23);
            this.batchConvertDestinationBtn.TabIndex = 7;
            this.batchConvertDestinationBtn.Text = "...";
            this.batchConvertDestinationBtn.UseVisualStyleBackColor = true;
            this.batchConvertDestinationBtn.Click += new System.EventHandler(this.batchConvertDestinationBtn_Click);
            // 
            // batchConvertDestinationTb
            // 
            this.batchConvertDestinationTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertDestinationTb.Location = new System.Drawing.Point(115, 245);
            this.batchConvertDestinationTb.Name = "batchConvertDestinationTb";
            this.batchConvertDestinationTb.Size = new System.Drawing.Size(598, 23);
            this.batchConvertDestinationTb.TabIndex = 6;
            this.batchConvertDestinationTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batchConvertDestinationTb_KeyPress);
            // 
            // batchConvertDestinationLbl
            // 
            this.batchConvertDestinationLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.batchConvertDestinationLbl.AutoSize = true;
            this.batchConvertDestinationLbl.Location = new System.Drawing.Point(3, 248);
            this.batchConvertDestinationLbl.Name = "batchConvertDestinationLbl";
            this.batchConvertDestinationLbl.Size = new System.Drawing.Size(84, 15);
            this.batchConvertDestinationLbl.TabIndex = 5;
            this.batchConvertDestinationLbl.Text = "Destination dir";
            // 
            // batchConvertSourceBtn
            // 
            this.batchConvertSourceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertSourceBtn.Location = new System.Drawing.Point(719, 215);
            this.batchConvertSourceBtn.Name = "batchConvertSourceBtn";
            this.batchConvertSourceBtn.Size = new System.Drawing.Size(32, 23);
            this.batchConvertSourceBtn.TabIndex = 4;
            this.batchConvertSourceBtn.Text = "...";
            this.batchConvertSourceBtn.UseVisualStyleBackColor = true;
            this.batchConvertSourceBtn.Click += new System.EventHandler(this.batchConvertSourceBtn_Click);
            // 
            // batchConvertSourceTb
            // 
            this.batchConvertSourceTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertSourceTb.Location = new System.Drawing.Point(115, 216);
            this.batchConvertSourceTb.Name = "batchConvertSourceTb";
            this.batchConvertSourceTb.Size = new System.Drawing.Size(598, 23);
            this.batchConvertSourceTb.TabIndex = 3;
            this.batchConvertSourceTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.batchConvertSourceTb_KeyPress);
            // 
            // batchConvertSourceLbl
            // 
            this.batchConvertSourceLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.batchConvertSourceLbl.AutoSize = true;
            this.batchConvertSourceLbl.Location = new System.Drawing.Point(3, 220);
            this.batchConvertSourceLbl.Name = "batchConvertSourceLbl";
            this.batchConvertSourceLbl.Size = new System.Drawing.Size(60, 15);
            this.batchConvertSourceLbl.TabIndex = 2;
            this.batchConvertSourceLbl.Text = "Source dir";
            // 
            // batchConvertInstructionsTb
            // 
            this.batchConvertInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchConvertInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.batchConvertInstructionsTb.Multiline = true;
            this.batchConvertInstructionsTb.Name = "batchConvertInstructionsTb";
            this.batchConvertInstructionsTb.ReadOnly = true;
            this.batchConvertInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.batchConvertInstructionsTb.Size = new System.Drawing.Size(748, 206);
            this.batchConvertInstructionsTb.TabIndex = 1;
            this.batchConvertInstructionsTb.Text = "For each image in source directory:\r\n\r\n* copy to destination directory\r\n* convert" +
    " to xlsx\r\n* match colors to nearest DMC\r\n* create cross stitch pattern";
            // 
            // toPngTabPage
            // 
            this.toPngTabPage.Controls.Add(this.toPngNud);
            this.toPngTabPage.Controls.Add(this.toPngScaleRb);
            this.toPngTabPage.Controls.Add(this.toPngOriginalRb);
            this.toPngTabPage.Controls.Add(this.toPngInstructionsTb);
            this.toPngTabPage.Controls.Add(this.createPngBtn);
            this.toPngTabPage.Controls.Add(this.toPngOutputBtn);
            this.toPngTabPage.Controls.Add(this.toPngOutputTb);
            this.toPngTabPage.Controls.Add(this.toPngOutputLbl);
            this.toPngTabPage.Location = new System.Drawing.Point(4, 24);
            this.toPngTabPage.Name = "toPngTabPage";
            this.toPngTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.toPngTabPage.Size = new System.Drawing.Size(754, 353);
            this.toPngTabPage.TabIndex = 7;
            this.toPngTabPage.Text = "To png";
            this.toPngTabPage.UseVisualStyleBackColor = true;
            // 
            // toPngNud
            // 
            this.toPngNud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toPngNud.Location = new System.Drawing.Point(87, 270);
            this.toPngNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.toPngNud.Name = "toPngNud";
            this.toPngNud.Size = new System.Drawing.Size(50, 23);
            this.toPngNud.TabIndex = 24;
            this.toPngNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // toPngScaleRb
            // 
            this.toPngScaleRb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toPngScaleRb.AutoSize = true;
            this.toPngScaleRb.Location = new System.Drawing.Point(6, 270);
            this.toPngScaleRb.Name = "toPngScaleRb";
            this.toPngScaleRb.Size = new System.Drawing.Size(75, 19);
            this.toPngScaleRb.TabIndex = 23;
            this.toPngScaleRb.Text = "Scale to x";
            this.toPngScaleRb.UseVisualStyleBackColor = true;
            this.toPngScaleRb.CheckedChanged += new System.EventHandler(this.enableScaleUpDown);
            // 
            // toPngOriginalRb
            // 
            this.toPngOriginalRb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toPngOriginalRb.AutoSize = true;
            this.toPngOriginalRb.Checked = true;
            this.toPngOriginalRb.Location = new System.Drawing.Point(6, 245);
            this.toPngOriginalRb.Name = "toPngOriginalRb";
            this.toPngOriginalRb.Size = new System.Drawing.Size(89, 19);
            this.toPngOriginalRb.TabIndex = 22;
            this.toPngOriginalRb.TabStop = true;
            this.toPngOriginalRb.Text = "Original size";
            this.toPngOriginalRb.UseVisualStyleBackColor = true;
            this.toPngOriginalRb.CheckedChanged += new System.EventHandler(this.enableScaleUpDown);
            // 
            // toPngInstructionsTb
            // 
            this.toPngInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toPngInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.toPngInstructionsTb.Multiline = true;
            this.toPngInstructionsTb.Name = "toPngInstructionsTb";
            this.toPngInstructionsTb.ReadOnly = true;
            this.toPngInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.toPngInstructionsTb.Size = new System.Drawing.Size(748, 206);
            this.toPngInstructionsTb.TabIndex = 18;
            this.toPngInstructionsTb.Text = resources.GetString("toPngInstructionsTb.Text");
            // 
            // createPngBtn
            // 
            this.createPngBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createPngBtn.Location = new System.Drawing.Point(591, 317);
            this.createPngBtn.Name = "createPngBtn";
            this.createPngBtn.Size = new System.Drawing.Size(160, 23);
            this.createPngBtn.TabIndex = 25;
            this.createPngBtn.Text = "Create png";
            this.createPngBtn.UseVisualStyleBackColor = true;
            this.createPngBtn.Click += new System.EventHandler(this.createPngBtn_Click);
            // 
            // toPngOutputBtn
            // 
            this.toPngOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toPngOutputBtn.Location = new System.Drawing.Point(719, 215);
            this.toPngOutputBtn.Name = "toPngOutputBtn";
            this.toPngOutputBtn.Size = new System.Drawing.Size(32, 23);
            this.toPngOutputBtn.TabIndex = 21;
            this.toPngOutputBtn.Text = "...";
            this.toPngOutputBtn.UseVisualStyleBackColor = true;
            this.toPngOutputBtn.Click += new System.EventHandler(this.toPngOutputBtn_Click);
            // 
            // toPngOutputTb
            // 
            this.toPngOutputTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toPngOutputTb.Location = new System.Drawing.Point(101, 216);
            this.toPngOutputTb.Name = "toPngOutputTb";
            this.toPngOutputTb.Size = new System.Drawing.Size(612, 23);
            this.toPngOutputTb.TabIndex = 20;
            this.toPngOutputTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toPngOutputTb_KeyPress);
            // 
            // toPngOutputLbl
            // 
            this.toPngOutputLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toPngOutputLbl.AutoSize = true;
            this.toPngOutputLbl.Location = new System.Drawing.Point(6, 219);
            this.toPngOutputLbl.Name = "toPngOutputLbl";
            this.toPngOutputLbl.Size = new System.Drawing.Size(89, 15);
            this.toPngOutputLbl.TabIndex = 19;
            this.toPngOutputLbl.Text = "Png output file:";
            // 
            // crtBlurTabPage
            // 
            this.crtBlurTabPage.Controls.Add(this.crtBlurInstructionsTb);
            this.crtBlurTabPage.Controls.Add(this.createCrtBlurBtn);
            this.crtBlurTabPage.Controls.Add(this.crtBlurOutputBtn);
            this.crtBlurTabPage.Controls.Add(this.crtBlurOutputTb);
            this.crtBlurTabPage.Controls.Add(this.crtBlurOutputLbl);
            this.crtBlurTabPage.Location = new System.Drawing.Point(4, 24);
            this.crtBlurTabPage.Name = "crtBlurTabPage";
            this.crtBlurTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.crtBlurTabPage.Size = new System.Drawing.Size(754, 353);
            this.crtBlurTabPage.TabIndex = 4;
            this.crtBlurTabPage.Text = "CRT Blur";
            this.crtBlurTabPage.UseVisualStyleBackColor = true;
            // 
            // crtBlurInstructionsTb
            // 
            this.crtBlurInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtBlurInstructionsTb.Location = new System.Drawing.Point(3, 3);
            this.crtBlurInstructionsTb.Multiline = true;
            this.crtBlurInstructionsTb.Name = "crtBlurInstructionsTb";
            this.crtBlurInstructionsTb.ReadOnly = true;
            this.crtBlurInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.crtBlurInstructionsTb.Size = new System.Drawing.Size(748, 206);
            this.crtBlurInstructionsTb.TabIndex = 17;
            this.crtBlurInstructionsTb.Text = "Apply a CRT blur effect to your design.\r\n\r\nALL non-transparent pixels are treated" +
    " as white, then the CRT blur effect is applied.";
            // 
            // createCrtBlurBtn
            // 
            this.createCrtBlurBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createCrtBlurBtn.Location = new System.Drawing.Point(591, 317);
            this.createCrtBlurBtn.Name = "createCrtBlurBtn";
            this.createCrtBlurBtn.Size = new System.Drawing.Size(160, 23);
            this.createCrtBlurBtn.TabIndex = 16;
            this.createCrtBlurBtn.Text = "Create CRT Blur";
            this.createCrtBlurBtn.UseVisualStyleBackColor = true;
            this.createCrtBlurBtn.Click += new System.EventHandler(this.createCrtBlurBtn_Click);
            // 
            // crtBlurOutputBtn
            // 
            this.crtBlurOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.crtBlurOutputBtn.Location = new System.Drawing.Point(719, 215);
            this.crtBlurOutputBtn.Name = "crtBlurOutputBtn";
            this.crtBlurOutputBtn.Size = new System.Drawing.Size(32, 23);
            this.crtBlurOutputBtn.TabIndex = 12;
            this.crtBlurOutputBtn.Text = "...";
            this.crtBlurOutputBtn.UseVisualStyleBackColor = true;
            this.crtBlurOutputBtn.Click += new System.EventHandler(this.crtBlurOutputBtn_Click);
            // 
            // crtBlurOutputTb
            // 
            this.crtBlurOutputTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crtBlurOutputTb.Location = new System.Drawing.Point(121, 216);
            this.crtBlurOutputTb.Name = "crtBlurOutputTb";
            this.crtBlurOutputTb.Size = new System.Drawing.Size(592, 23);
            this.crtBlurOutputTb.TabIndex = 11;
            this.crtBlurOutputTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.crtBlurOutputTb_KeyPress);
            // 
            // crtBlurOutputLbl
            // 
            this.crtBlurOutputLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.crtBlurOutputLbl.AutoSize = true;
            this.crtBlurOutputLbl.Location = new System.Drawing.Point(3, 219);
            this.crtBlurOutputLbl.Name = "crtBlurOutputLbl";
            this.crtBlurOutputLbl.Size = new System.Drawing.Size(112, 15);
            this.crtBlurOutputLbl.TabIndex = 10;
            this.crtBlurOutputLbl.Text = "CRT Blur output file:";
            // 
            // statsTabPage
            // 
            this.statsTabPage.Controls.Add(this.statsPanel1);
            this.statsTabPage.Location = new System.Drawing.Point(4, 24);
            this.statsTabPage.Name = "statsTabPage";
            this.statsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.statsTabPage.Size = new System.Drawing.Size(754, 353);
            this.statsTabPage.TabIndex = 9;
            this.statsTabPage.Text = "Stats";
            this.statsTabPage.UseVisualStyleBackColor = true;
            // 
            // statsPanel1
            // 
            this.statsPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsPanel1.Location = new System.Drawing.Point(3, 3);
            this.statsPanel1.Name = "statsPanel1";
            this.statsPanel1.Size = new System.Drawing.Size(748, 347);
            this.statsPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 435);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.fileNameBtn);
            this.Controls.Add(this.fileNameTb);
            this.Controls.Add(this.fileNameLbl);
            this.Name = "Form1";
            this.Text = "Xstitch Xcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.tabControl.ResumeLayout(false);
            this.createPatternTabPage.ResumeLayout(false);
            this.findDmcColorsTabPage.ResumeLayout(false);
            this.findDmcColorsTabPage.PerformLayout();
            this.replaceColorTabPage.ResumeLayout(false);
            this.replaceColorTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newColorPb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldColorPb)).EndInit();
            this.replaceColorNaiveTabPage.ResumeLayout(false);
            this.replaceColorNaiveTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newColorNaivePb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oldColorNaivePb)).EndInit();
            this.batchConvertTabPage.ResumeLayout(false);
            this.batchConvertTabPage.PerformLayout();
            this.toPngTabPage.ResumeLayout(false);
            this.toPngTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).EndInit();
            this.crtBlurTabPage.ResumeLayout(false);
            this.crtBlurTabPage.PerformLayout();
            this.statsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.TextBox fileNameTb;
        private System.Windows.Forms.Button fileNameBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage findDmcColorsTabPage;
        private System.Windows.Forms.TabPage replaceColorTabPage;
        private System.Windows.Forms.Button beginColorReplaceBtn;
        private System.Windows.Forms.PictureBox newColorPb;
        private System.Windows.Forms.TextBox newColorTb;
        private System.Windows.Forms.Label newColorLbl;
        private System.Windows.Forms.PictureBox oldColorPb;
        private System.Windows.Forms.TextBox oldColorTb;
        private System.Windows.Forms.Label oldColorLbl;
        private System.Windows.Forms.CheckBox replaceColorBakCb;
        private System.Windows.Forms.TextBox replaceColorInstructionsTb;
        private System.Windows.Forms.Label newIsDmcLbl;
        private System.Windows.Forms.Label oldIsDmcLbl;
        private System.Windows.Forms.TextBox findDmcColorsInstructionsTb;
        private System.Windows.Forms.Button findDmcColorsBtn;
        private System.Windows.Forms.TabPage crtBlurTabPage;
        private System.Windows.Forms.TextBox crtBlurInstructionsTb;
        private System.Windows.Forms.Button createCrtBlurBtn;
        private System.Windows.Forms.Button crtBlurOutputBtn;
        private System.Windows.Forms.TextBox crtBlurOutputTb;
        private System.Windows.Forms.Label crtBlurOutputLbl;
        private System.Windows.Forms.TabPage replaceColorNaiveTabPage;
        private System.Windows.Forms.Label newIsDmcNaiveLbl;
        private System.Windows.Forms.Label oldIsDmcNaiveLbl;
        private System.Windows.Forms.TextBox replaceColorNaiveInstructionsTb;
        private System.Windows.Forms.Button beginColorReplaceNaiveBtn;
        private System.Windows.Forms.PictureBox newColorNaivePb;
        private System.Windows.Forms.TextBox newColorNaiveTb;
        private System.Windows.Forms.Label newColorNaiveLbl;
        private System.Windows.Forms.PictureBox oldColorNaivePb;
        private System.Windows.Forms.TextBox oldColorNaiveTb;
        private System.Windows.Forms.Label oldColorNaiveLbl;
        private System.Windows.Forms.CheckBox replaceColorNaiveBakCb;
        private System.Windows.Forms.TabPage batchConvertTabPage;
        private System.Windows.Forms.TextBox batchConvertInstructionsTb;
        private System.Windows.Forms.Button batchConvertStart;
        private System.Windows.Forms.Button batchConvertDestinationBtn;
        private System.Windows.Forms.TextBox batchConvertDestinationTb;
        private System.Windows.Forms.Label batchConvertDestinationLbl;
        private System.Windows.Forms.Button batchConvertSourceBtn;
        private System.Windows.Forms.TextBox batchConvertSourceTb;
        private System.Windows.Forms.Label batchConvertSourceLbl;
        private System.Windows.Forms.TabPage toPngTabPage;
        private System.Windows.Forms.TextBox toPngInstructionsTb;
        private System.Windows.Forms.Button createPngBtn;
        private System.Windows.Forms.Button toPngOutputBtn;
        private System.Windows.Forms.TextBox toPngOutputTb;
        private System.Windows.Forms.Label toPngOutputLbl;
        private System.Windows.Forms.RadioButton toPngScaleRb;
        private System.Windows.Forms.RadioButton toPngOriginalRb;
        private System.Windows.Forms.NumericUpDown toPngNud;
        private System.Windows.Forms.TabPage createPatternTabPage;
        private XstitchXcelWinFormsLib.Panels.CreatePatternSplitPanel createPatternSplitPanel1;
        private System.Windows.Forms.TabPage statsTabPage;
        private XstitchXcelWinFormsLib.Panels.StatsPanel statsPanel1;
    }
}

