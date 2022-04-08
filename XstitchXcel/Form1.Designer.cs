
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
            this.statsTabPage = new System.Windows.Forms.TabPage();
            this.statsPanel1 = new XstitchXcelWinFormsLib.Panels.StatsPanel();
            this.findDmcColorsTabPage = new System.Windows.Forms.TabPage();
            this.findDmcColorsSplitPanel1 = new XstitchXcelWinFormsLib.Panels.FindDmcColorsSplitPanel();
            this.replaceColorTabPage = new System.Windows.Forms.TabPage();
            this.replaceColorInPatternSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternSplitPanel();
            this.replaceColorNaiveTabPage = new System.Windows.Forms.TabPage();
            this.replaceColorNaiveSplitPanel1 = new XstitchXcelWinFormsLib.Panels.ReplaceColorNaiveSplitPanel();
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
            this.tabControl.SuspendLayout();
            this.createPatternTabPage.SuspendLayout();
            this.statsTabPage.SuspendLayout();
            this.findDmcColorsTabPage.SuspendLayout();
            this.replaceColorTabPage.SuspendLayout();
            this.replaceColorNaiveTabPage.SuspendLayout();
            this.batchConvertTabPage.SuspendLayout();
            this.toPngTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).BeginInit();
            this.crtBlurTabPage.SuspendLayout();
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
            // findDmcColorsTabPage
            // 
            this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsSplitPanel1);
            this.findDmcColorsTabPage.Location = new System.Drawing.Point(4, 24);
            this.findDmcColorsTabPage.Name = "findDmcColorsTabPage";
            this.findDmcColorsTabPage.Size = new System.Drawing.Size(754, 353);
            this.findDmcColorsTabPage.TabIndex = 10;
            this.findDmcColorsTabPage.Text = "Find DMC Colors";
            this.findDmcColorsTabPage.UseVisualStyleBackColor = true;
            // 
            // findDmcColorsSplitPanel1
            // 
            this.findDmcColorsSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findDmcColorsSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.findDmcColorsSplitPanel1.Name = "findDmcColorsSplitPanel1";
            this.findDmcColorsSplitPanel1.Size = new System.Drawing.Size(754, 353);
            this.findDmcColorsSplitPanel1.TabIndex = 0;
            // 
            // replaceColorTabPage
            // 
            this.replaceColorTabPage.Controls.Add(this.replaceColorInPatternSplitPanel1);
            this.replaceColorTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorTabPage.Name = "replaceColorTabPage";
            this.replaceColorTabPage.Size = new System.Drawing.Size(754, 353);
            this.replaceColorTabPage.TabIndex = 11;
            this.replaceColorTabPage.Text = "Replace Color";
            this.replaceColorTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorInPatternSplitPanel1
            // 
            this.replaceColorInPatternSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replaceColorInPatternSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.replaceColorInPatternSplitPanel1.Name = "replaceColorInPatternSplitPanel1";
            this.replaceColorInPatternSplitPanel1.Size = new System.Drawing.Size(754, 353);
            this.replaceColorInPatternSplitPanel1.TabIndex = 0;
            // 
            // replaceColorNaiveTabPage
            // 
            this.replaceColorNaiveTabPage.Controls.Add(this.replaceColorNaiveSplitPanel1);
            this.replaceColorNaiveTabPage.Location = new System.Drawing.Point(4, 24);
            this.replaceColorNaiveTabPage.Name = "replaceColorNaiveTabPage";
            this.replaceColorNaiveTabPage.Size = new System.Drawing.Size(754, 353);
            this.replaceColorNaiveTabPage.TabIndex = 12;
            this.replaceColorNaiveTabPage.Text = "Replace Color (naive)";
            this.replaceColorNaiveTabPage.UseVisualStyleBackColor = true;
            // 
            // replaceColorNaiveSplitPanel1
            // 
            this.replaceColorNaiveSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replaceColorNaiveSplitPanel1.Location = new System.Drawing.Point(0, 0);
            this.replaceColorNaiveSplitPanel1.Name = "replaceColorNaiveSplitPanel1";
            this.replaceColorNaiveSplitPanel1.Size = new System.Drawing.Size(754, 353);
            this.replaceColorNaiveSplitPanel1.TabIndex = 0;
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
            this.statsTabPage.ResumeLayout(false);
            this.findDmcColorsTabPage.ResumeLayout(false);
            this.replaceColorTabPage.ResumeLayout(false);
            this.replaceColorNaiveTabPage.ResumeLayout(false);
            this.batchConvertTabPage.ResumeLayout(false);
            this.batchConvertTabPage.PerformLayout();
            this.toPngTabPage.ResumeLayout(false);
            this.toPngTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toPngNud)).EndInit();
            this.crtBlurTabPage.ResumeLayout(false);
            this.crtBlurTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.TextBox fileNameTb;
        private System.Windows.Forms.Button fileNameBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage crtBlurTabPage;
        private System.Windows.Forms.TextBox crtBlurInstructionsTb;
        private System.Windows.Forms.Button createCrtBlurBtn;
        private System.Windows.Forms.Button crtBlurOutputBtn;
        private System.Windows.Forms.TextBox crtBlurOutputTb;
        private System.Windows.Forms.Label crtBlurOutputLbl;
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
        private System.Windows.Forms.TabPage findDmcColorsTabPage;
        private XstitchXcelWinFormsLib.Panels.FindDmcColorsSplitPanel findDmcColorsSplitPanel1;
        private System.Windows.Forms.TabPage replaceColorTabPage;
        private XstitchXcelWinFormsLib.Panels.ReplaceColorInPatternSplitPanel replaceColorInPatternSplitPanel1;
        private XstitchXcelWinFormsLib.Panels.StatsPanel statsPanel1;
        private System.Windows.Forms.TabPage replaceColorNaiveTabPage;
        private XstitchXcelWinFormsLib.Panels.ReplaceColorNaiveSplitPanel replaceColorNaiveSplitPanel1;
    }
}

