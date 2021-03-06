﻿
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
			this.createPatternInstructionsTb = new System.Windows.Forms.TextBox();
			this.createPatternBtn = new System.Windows.Forms.Button();
			this.colorsAndSymbolsCb = new System.Windows.Forms.CheckBox();
			this.symbolsCb = new System.Windows.Forms.CheckBox();
			this.colorsCb = new System.Windows.Forms.CheckBox();
			this.patternOutputBtn = new System.Windows.Forms.Button();
			this.patternOutputTb = new System.Windows.Forms.TextBox();
			this.patternOutputLbl = new System.Windows.Forms.Label();
			this.statsTabPage = new System.Windows.Forms.TabPage();
			this.generateStatsBtn = new System.Windows.Forms.Button();
			this.statsDgv = new System.Windows.Forms.DataGridView();
			this.qtyStitches = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.minSkeins = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.maxSkeins = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dmcNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dmcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.findDmcColorsTabPage = new System.Windows.Forms.TabPage();
			this.findDmcColorsBtn = new System.Windows.Forms.Button();
			this.findDmcColorsInstructionsTb = new System.Windows.Forms.TextBox();
			this.replaceColorTabPage = new System.Windows.Forms.TabPage();
			this.newIsDmcLbl = new System.Windows.Forms.Label();
			this.oldIsDmcLbl = new System.Windows.Forms.Label();
			this.hexLbl = new System.Windows.Forms.Label();
			this.replaceColorInstructionsTb = new System.Windows.Forms.TextBox();
			this.beginColorFixBtn = new System.Windows.Forms.Button();
			this.newColorPb = new System.Windows.Forms.PictureBox();
			this.newColorTb = new System.Windows.Forms.TextBox();
			this.newColorLbl = new System.Windows.Forms.Label();
			this.oldColorPb = new System.Windows.Forms.PictureBox();
			this.oldColorTb = new System.Windows.Forms.TextBox();
			this.oldColorLbl = new System.Windows.Forms.Label();
			this.replaceColorBakCb = new System.Windows.Forms.CheckBox();
			this.tabControl.SuspendLayout();
			this.createPatternTabPage.SuspendLayout();
			this.statsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statsDgv)).BeginInit();
			this.findDmcColorsTabPage.SuspendLayout();
			this.replaceColorTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.newColorPb)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.oldColorPb)).BeginInit();
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
			this.fileNameTb.Size = new System.Drawing.Size(601, 23);
			this.fileNameTb.TabIndex = 1;
			this.fileNameTb.TextChanged += new System.EventHandler(this.fileNameTb_TextChanged);
			// 
			// fileNameBtn
			// 
			this.fileNameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.fileNameBtn.Location = new System.Drawing.Point(681, 12);
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
			this.tabControl.Location = new System.Drawing.Point(12, 42);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(701, 334);
			this.tabControl.TabIndex = 3;
			// 
			// createPatternTabPage
			// 
			this.createPatternTabPage.Controls.Add(this.createPatternInstructionsTb);
			this.createPatternTabPage.Controls.Add(this.createPatternBtn);
			this.createPatternTabPage.Controls.Add(this.colorsAndSymbolsCb);
			this.createPatternTabPage.Controls.Add(this.symbolsCb);
			this.createPatternTabPage.Controls.Add(this.colorsCb);
			this.createPatternTabPage.Controls.Add(this.patternOutputBtn);
			this.createPatternTabPage.Controls.Add(this.patternOutputTb);
			this.createPatternTabPage.Controls.Add(this.patternOutputLbl);
			this.createPatternTabPage.Location = new System.Drawing.Point(4, 24);
			this.createPatternTabPage.Name = "createPatternTabPage";
			this.createPatternTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.createPatternTabPage.Size = new System.Drawing.Size(693, 306);
			this.createPatternTabPage.TabIndex = 0;
			this.createPatternTabPage.Text = "Create Pattern";
			this.createPatternTabPage.UseVisualStyleBackColor = true;
			// 
			// createPatternInstructionsTb
			// 
			this.createPatternInstructionsTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.createPatternInstructionsTb.Location = new System.Drawing.Point(3, 3);
			this.createPatternInstructionsTb.Multiline = true;
			this.createPatternInstructionsTb.Name = "createPatternInstructionsTb";
			this.createPatternInstructionsTb.ReadOnly = true;
			this.createPatternInstructionsTb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.createPatternInstructionsTb.Size = new System.Drawing.Size(687, 168);
			this.createPatternInstructionsTb.TabIndex = 9;
			this.createPatternInstructionsTb.Text = resources.GetString("createPatternInstructionsTb.Text");
			// 
			// createPatternBtn
			// 
			this.createPatternBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.createPatternBtn.Location = new System.Drawing.Point(530, 279);
			this.createPatternBtn.Name = "createPatternBtn";
			this.createPatternBtn.Size = new System.Drawing.Size(160, 23);
			this.createPatternBtn.TabIndex = 8;
			this.createPatternBtn.Text = "Create Pattern";
			this.createPatternBtn.UseVisualStyleBackColor = true;
			this.createPatternBtn.Click += new System.EventHandler(this.createPatternBtn_Click);
			// 
			// colorsAndSymbolsCb
			// 
			this.colorsAndSymbolsCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.colorsAndSymbolsCb.AutoSize = true;
			this.colorsAndSymbolsCb.Checked = true;
			this.colorsAndSymbolsCb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.colorsAndSymbolsCb.Location = new System.Drawing.Point(35, 261);
			this.colorsAndSymbolsCb.Name = "colorsAndSymbolsCb";
			this.colorsAndSymbolsCb.Size = new System.Drawing.Size(130, 19);
			this.colorsAndSymbolsCb.TabIndex = 7;
			this.colorsAndSymbolsCb.Text = "Colors and symbols";
			this.colorsAndSymbolsCb.UseVisualStyleBackColor = true;
			// 
			// symbolsCb
			// 
			this.symbolsCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.symbolsCb.AutoSize = true;
			this.symbolsCb.Checked = true;
			this.symbolsCb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.symbolsCb.Location = new System.Drawing.Point(35, 236);
			this.symbolsCb.Name = "symbolsCb";
			this.symbolsCb.Size = new System.Drawing.Size(71, 19);
			this.symbolsCb.TabIndex = 6;
			this.symbolsCb.Text = "Symbols";
			this.symbolsCb.UseVisualStyleBackColor = true;
			// 
			// colorsCb
			// 
			this.colorsCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.colorsCb.AutoSize = true;
			this.colorsCb.Checked = true;
			this.colorsCb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.colorsCb.Location = new System.Drawing.Point(35, 211);
			this.colorsCb.Name = "colorsCb";
			this.colorsCb.Size = new System.Drawing.Size(60, 19);
			this.colorsCb.TabIndex = 5;
			this.colorsCb.Text = "Colors";
			this.colorsCb.UseVisualStyleBackColor = true;
			// 
			// patternOutputBtn
			// 
			this.patternOutputBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.patternOutputBtn.Location = new System.Drawing.Point(658, 177);
			this.patternOutputBtn.Name = "patternOutputBtn";
			this.patternOutputBtn.Size = new System.Drawing.Size(32, 23);
			this.patternOutputBtn.TabIndex = 3;
			this.patternOutputBtn.Text = "...";
			this.patternOutputBtn.UseVisualStyleBackColor = true;
			this.patternOutputBtn.Click += new System.EventHandler(this.patternOutputBtn_Click);
			// 
			// patternOutputTb
			// 
			this.patternOutputTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.patternOutputTb.Location = new System.Drawing.Point(115, 178);
			this.patternOutputTb.Name = "patternOutputTb";
			this.patternOutputTb.Size = new System.Drawing.Size(537, 23);
			this.patternOutputTb.TabIndex = 1;
			// 
			// patternOutputLbl
			// 
			this.patternOutputLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.patternOutputLbl.AutoSize = true;
			this.patternOutputLbl.Location = new System.Drawing.Point(3, 181);
			this.patternOutputLbl.Name = "patternOutputLbl";
			this.patternOutputLbl.Size = new System.Drawing.Size(106, 15);
			this.patternOutputLbl.TabIndex = 0;
			this.patternOutputLbl.Text = "Pattern output file:";
			// 
			// statsTabPage
			// 
			this.statsTabPage.Controls.Add(this.generateStatsBtn);
			this.statsTabPage.Controls.Add(this.statsDgv);
			this.statsTabPage.Location = new System.Drawing.Point(4, 24);
			this.statsTabPage.Name = "statsTabPage";
			this.statsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.statsTabPage.Size = new System.Drawing.Size(693, 306);
			this.statsTabPage.TabIndex = 1;
			this.statsTabPage.Text = "Stats";
			this.statsTabPage.UseVisualStyleBackColor = true;
			// 
			// generateStatsBtn
			// 
			this.generateStatsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.generateStatsBtn.Location = new System.Drawing.Point(530, 280);
			this.generateStatsBtn.Name = "generateStatsBtn";
			this.generateStatsBtn.Size = new System.Drawing.Size(160, 23);
			this.generateStatsBtn.TabIndex = 1;
			this.generateStatsBtn.Text = "Generate Stats";
			this.generateStatsBtn.UseVisualStyleBackColor = true;
			this.generateStatsBtn.Click += new System.EventHandler(this.generateStatsBtn_Click);
			// 
			// statsDgv
			// 
			this.statsDgv.AllowUserToAddRows = false;
			this.statsDgv.AllowUserToDeleteRows = false;
			this.statsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.statsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.statsDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qtyStitches,
            this.minSkeins,
            this.maxSkeins,
            this.hex,
            this.dmcNumber,
            this.dmcName});
			this.statsDgv.EnableHeadersVisualStyles = false;
			this.statsDgv.Location = new System.Drawing.Point(3, 3);
			this.statsDgv.Name = "statsDgv";
			this.statsDgv.ReadOnly = true;
			this.statsDgv.RowHeadersVisible = false;
			this.statsDgv.RowTemplate.Height = 25;
			this.statsDgv.Size = new System.Drawing.Size(687, 271);
			this.statsDgv.TabIndex = 0;
			// 
			// qtyStitches
			// 
			this.qtyStitches.FillWeight = 93.1677F;
			this.qtyStitches.HeaderText = "# Stitches";
			this.qtyStitches.Name = "qtyStitches";
			this.qtyStitches.ReadOnly = true;
			// 
			// minSkeins
			// 
			this.minSkeins.FillWeight = 96.51846F;
			this.minSkeins.HeaderText = "Min skeins";
			this.minSkeins.Name = "minSkeins";
			this.minSkeins.ReadOnly = true;
			// 
			// maxSkeins
			// 
			this.maxSkeins.FillWeight = 99.34892F;
			this.maxSkeins.HeaderText = "Max skeins";
			this.maxSkeins.Name = "maxSkeins";
			this.maxSkeins.ReadOnly = true;
			// 
			// hex
			// 
			this.hex.FillWeight = 101.7399F;
			this.hex.HeaderText = "Hex #";
			this.hex.Name = "hex";
			this.hex.ReadOnly = true;
			// 
			// dmcNumber
			// 
			this.dmcNumber.FillWeight = 103.7595F;
			this.dmcNumber.HeaderText = "DMC #";
			this.dmcNumber.Name = "dmcNumber";
			this.dmcNumber.ReadOnly = true;
			// 
			// dmcName
			// 
			this.dmcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dmcName.FillWeight = 105.4656F;
			this.dmcName.HeaderText = "DMC name";
			this.dmcName.Name = "dmcName";
			this.dmcName.ReadOnly = true;
			// 
			// findDmcColorsTabPage
			// 
			this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsBtn);
			this.findDmcColorsTabPage.Controls.Add(this.findDmcColorsInstructionsTb);
			this.findDmcColorsTabPage.Location = new System.Drawing.Point(4, 24);
			this.findDmcColorsTabPage.Name = "findDmcColorsTabPage";
			this.findDmcColorsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.findDmcColorsTabPage.Size = new System.Drawing.Size(693, 306);
			this.findDmcColorsTabPage.TabIndex = 2;
			this.findDmcColorsTabPage.Text = "Find DMC Colors";
			this.findDmcColorsTabPage.UseVisualStyleBackColor = true;
			// 
			// findDmcColorsBtn
			// 
			this.findDmcColorsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.findDmcColorsBtn.Location = new System.Drawing.Point(530, 280);
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
			this.findDmcColorsInstructionsTb.Size = new System.Drawing.Size(687, 168);
			this.findDmcColorsInstructionsTb.TabIndex = 10;
			this.findDmcColorsInstructionsTb.Text = "Finds the non-DMC colors in your file. Creates report with the closest DMC matche" +
    "s";
			// 
			// replaceColorTabPage
			// 
			this.replaceColorTabPage.Controls.Add(this.newIsDmcLbl);
			this.replaceColorTabPage.Controls.Add(this.oldIsDmcLbl);
			this.replaceColorTabPage.Controls.Add(this.hexLbl);
			this.replaceColorTabPage.Controls.Add(this.replaceColorInstructionsTb);
			this.replaceColorTabPage.Controls.Add(this.beginColorFixBtn);
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
			this.replaceColorTabPage.Size = new System.Drawing.Size(693, 306);
			this.replaceColorTabPage.TabIndex = 3;
			this.replaceColorTabPage.Text = "Replace Color";
			this.replaceColorTabPage.UseVisualStyleBackColor = true;
			// 
			// newIsDmcLbl
			// 
			this.newIsDmcLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newIsDmcLbl.AutoSize = true;
			this.newIsDmcLbl.Location = new System.Drawing.Point(331, 246);
			this.newIsDmcLbl.Name = "newIsDmcLbl";
			this.newIsDmcLbl.Size = new System.Drawing.Size(38, 15);
			this.newIsDmcLbl.TabIndex = 13;
			this.newIsDmcLbl.Text = "label2";
			this.newIsDmcLbl.Visible = false;
			// 
			// oldIsDmcLbl
			// 
			this.oldIsDmcLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oldIsDmcLbl.AutoSize = true;
			this.oldIsDmcLbl.Location = new System.Drawing.Point(331, 217);
			this.oldIsDmcLbl.Name = "oldIsDmcLbl";
			this.oldIsDmcLbl.Size = new System.Drawing.Size(38, 15);
			this.oldIsDmcLbl.TabIndex = 12;
			this.oldIsDmcLbl.Text = "label1";
			this.oldIsDmcLbl.Visible = false;
			// 
			// hexLbl
			// 
			this.hexLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.hexLbl.AutoSize = true;
			this.hexLbl.Location = new System.Drawing.Point(81, 189);
			this.hexLbl.Name = "hexLbl";
			this.hexLbl.Size = new System.Drawing.Size(125, 15);
			this.hexLbl.TabIndex = 11;
			this.hexLbl.Text = "Hex code. Eg: #123456";
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
			this.replaceColorInstructionsTb.Size = new System.Drawing.Size(687, 158);
			this.replaceColorInstructionsTb.TabIndex = 10;
			this.replaceColorInstructionsTb.Text = resources.GetString("replaceColorInstructionsTb.Text");
			// 
			// beginColorFixBtn
			// 
			this.beginColorFixBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.beginColorFixBtn.Location = new System.Drawing.Point(530, 280);
			this.beginColorFixBtn.Name = "beginColorFixBtn";
			this.beginColorFixBtn.Size = new System.Drawing.Size(160, 23);
			this.beginColorFixBtn.TabIndex = 7;
			this.beginColorFixBtn.Text = "Begin color fix";
			this.beginColorFixBtn.UseVisualStyleBackColor = true;
			this.beginColorFixBtn.Click += new System.EventHandler(this.beginColorFixBtn_Click);
			// 
			// newColorPb
			// 
			this.newColorPb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newColorPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.newColorPb.Location = new System.Drawing.Point(207, 243);
			this.newColorPb.Name = "newColorPb";
			this.newColorPb.Size = new System.Drawing.Size(100, 23);
			this.newColorPb.TabIndex = 6;
			this.newColorPb.TabStop = false;
			this.newColorPb.Visible = false;
			// 
			// newColorTb
			// 
			this.newColorTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newColorTb.Location = new System.Drawing.Point(81, 243);
			this.newColorTb.Name = "newColorTb";
			this.newColorTb.Size = new System.Drawing.Size(100, 23);
			this.newColorTb.TabIndex = 5;
			this.newColorTb.TextChanged += new System.EventHandler(this.newColorTb_TextChanged);
			// 
			// newColorLbl
			// 
			this.newColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.newColorLbl.AutoSize = true;
			this.newColorLbl.Location = new System.Drawing.Point(3, 246);
			this.newColorLbl.Name = "newColorLbl";
			this.newColorLbl.Size = new System.Drawing.Size(64, 15);
			this.newColorLbl.TabIndex = 4;
			this.newColorLbl.Text = "New color:";
			// 
			// oldColorPb
			// 
			this.oldColorPb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oldColorPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.oldColorPb.Location = new System.Drawing.Point(207, 214);
			this.oldColorPb.Name = "oldColorPb";
			this.oldColorPb.Size = new System.Drawing.Size(100, 23);
			this.oldColorPb.TabIndex = 3;
			this.oldColorPb.TabStop = false;
			this.oldColorPb.Visible = false;
			// 
			// oldColorTb
			// 
			this.oldColorTb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oldColorTb.Location = new System.Drawing.Point(81, 214);
			this.oldColorTb.Name = "oldColorTb";
			this.oldColorTb.Size = new System.Drawing.Size(100, 23);
			this.oldColorTb.TabIndex = 2;
			this.oldColorTb.TextChanged += new System.EventHandler(this.oldColorTb_TextChanged);
			// 
			// oldColorLbl
			// 
			this.oldColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.oldColorLbl.AutoSize = true;
			this.oldColorLbl.Location = new System.Drawing.Point(3, 217);
			this.oldColorLbl.Name = "oldColorLbl";
			this.oldColorLbl.Size = new System.Drawing.Size(59, 15);
			this.oldColorLbl.TabIndex = 1;
			this.oldColorLbl.Text = "Old color:";
			// 
			// replaceColorBakCb
			// 
			this.replaceColorBakCb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.replaceColorBakCb.AutoSize = true;
			this.replaceColorBakCb.Location = new System.Drawing.Point(3, 167);
			this.replaceColorBakCb.Name = "replaceColorBakCb";
			this.replaceColorBakCb.Size = new System.Drawing.Size(234, 19);
			this.replaceColorBakCb.TabIndex = 0;
			this.replaceColorBakCb.Text = "Back up my file before making changes";
			this.replaceColorBakCb.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(725, 388);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.fileNameBtn);
			this.Controls.Add(this.fileNameTb);
			this.Controls.Add(this.fileNameLbl);
			this.Name = "Form1";
			this.Text = "Xstitch Xcel";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.tabControl.ResumeLayout(false);
			this.createPatternTabPage.ResumeLayout(false);
			this.createPatternTabPage.PerformLayout();
			this.statsTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statsDgv)).EndInit();
			this.findDmcColorsTabPage.ResumeLayout(false);
			this.findDmcColorsTabPage.PerformLayout();
			this.replaceColorTabPage.ResumeLayout(false);
			this.replaceColorTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.newColorPb)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.oldColorPb)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label fileNameLbl;
		private System.Windows.Forms.TextBox fileNameTb;
		private System.Windows.Forms.Button fileNameBtn;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage createPatternTabPage;
		private System.Windows.Forms.TabPage statsTabPage;
		private System.Windows.Forms.TabPage findDmcColorsTabPage;
		private System.Windows.Forms.TabPage replaceColorTabPage;
		private System.Windows.Forms.Button patternOutputBtn;
		private System.Windows.Forms.TextBox patternOutputTb;
		private System.Windows.Forms.Label patternOutputLbl;
		private System.Windows.Forms.Button createPatternBtn;
		private System.Windows.Forms.CheckBox colorsAndSymbolsCb;
		private System.Windows.Forms.CheckBox symbolsCb;
		private System.Windows.Forms.CheckBox colorsCb;
		private System.Windows.Forms.TextBox createPatternInstructionsTb;
		private System.Windows.Forms.Button generateStatsBtn;
		private System.Windows.Forms.DataGridView statsDgv;
		private System.Windows.Forms.DataGridViewTextBoxColumn qtyStitches;
		private System.Windows.Forms.DataGridViewTextBoxColumn minSkeins;
		private System.Windows.Forms.DataGridViewTextBoxColumn maxSkeins;
		private System.Windows.Forms.DataGridViewTextBoxColumn hex;
		private System.Windows.Forms.DataGridViewTextBoxColumn dmcNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn dmcName;
		private System.Windows.Forms.Button beginColorFixBtn;
		private System.Windows.Forms.PictureBox newColorPb;
		private System.Windows.Forms.TextBox newColorTb;
		private System.Windows.Forms.Label newColorLbl;
		private System.Windows.Forms.PictureBox oldColorPb;
		private System.Windows.Forms.TextBox oldColorTb;
		private System.Windows.Forms.Label oldColorLbl;
		private System.Windows.Forms.CheckBox replaceColorBakCb;
		private System.Windows.Forms.Label hexLbl;
		private System.Windows.Forms.TextBox replaceColorInstructionsTb;
		private System.Windows.Forms.Label newIsDmcLbl;
		private System.Windows.Forms.Label oldIsDmcLbl;
		private System.Windows.Forms.TextBox findDmcColorsInstructionsTb;
		private System.Windows.Forms.Button findDmcColorsBtn;
	}
}

